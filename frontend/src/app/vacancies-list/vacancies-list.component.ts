import { Component, OnInit } from '@angular/core';
import { Vacancy } from '../shared/models/vacancy.model';
import { VacancyService } from '../core/services/vacancy.service';
import { InvitationService } from '../core/services/invitation.service';
import { AuthHelper } from '../shared/helpers/auth-helper';
import { Router } from '@angular/router';
import { InvitationRequest } from '../shared/models/invitation-request.model';

@Component({
  selector: 'app-vacancies-list',
  templateUrl: './vacancies-list.component.html',
  styleUrls: ['./vacancies-list.component.sass']
})
export class VacanciesListComponent implements OnInit {

  visibleSidebar = false;
  display = false;
  searchString = '';

  totalRecords = 0;
  pageSize = 6;
  pageNumber = 1;

  vacancies: Vacancy[];
  selectedVacancy: Vacancy;

  uId = 0;
  employeeId: number;

  constructor(private vacancyService: VacancyService,
              private authHelper: AuthHelper,
              private invitationService: InvitationService,
              private router: Router) {

    this.uId = +this.authHelper.getCurrentUser().id;

              }

  ngOnInit() {

    this.loadVacanciesByRecruiterId(this.uId);

  }

  loadVacanciesByRecruiterId(id: number,
    pageSize: number = this.pageSize,
    pageNumber: number = this.pageNumber) {

      this.vacancyService.getByRecruiterIdWithPagination(id, pageSize, pageNumber)
      .subscribe((response) => {
        this.vacancies = response.body;
        const XPagination = JSON.parse(response.headers.get('X-Pagination'));

        if (XPagination !== null) {
          this.totalRecords = XPagination.TotalRecords;
        }
      });

  }

  showSideBar(employeeId: number) {

    this.employeeId = employeeId;
    this.visibleSidebar = true;

  }

  paginate(event) {

    this.pageNumber = ++event.page;
    const pageSize = event.rows;

    this.loadVacanciesByRecruiterId(this.uId, pageSize, this.pageNumber);

  }

  vacancyDetails(id: number) {

    this.router.navigate(['/vacancy-details', id]);

  }

  companyDetails(id: number) {

    this.router.navigate(['/company-details', id]);

  }

  showConfirmDialog(vacancy: Vacancy) {

    this.selectedVacancy = vacancy;
    this.display = true;

  }

  sendInvitation() {

    const request: InvitationRequest = {
      employeeId: this.employeeId,
      vacancyId: this.selectedVacancy.id
    };
    console.log(request);

    this.invitationService.create(request)
    .subscribe(data => { this.display = false; alert('Sended'); });

  }

}
