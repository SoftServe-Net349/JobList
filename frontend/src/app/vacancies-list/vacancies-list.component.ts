import { Component, OnInit, ViewChild } from '@angular/core';
import { Vacancy } from '../shared/models/vacancy.model';
import { VacancyService } from '../core/services/vacancy.service';
import { InvitationService } from '../core/services/invitation.service';
import { AuthHelper } from '../shared/helpers/auth-helper';
import { Router } from '@angular/router';
import { InvitationRequest } from '../shared/models/invitation-request.model';
import { MessageService, ConfirmationService, Message } from 'primeng/api';
import { PaginationQuery } from '../shared/filterQueries/PaginationQuery';
import { Paginator } from 'primeng/primeng';

@Component({
  selector: 'app-vacancies-list',
  templateUrl: './vacancies-list.component.html',
  styleUrls: ['./vacancies-list.component.sass'],
  providers: [MessageService, ConfirmationService]
})
export class VacanciesListComponent implements OnInit {

  visibleSidebar = false;
  searchedVacancy: Vacancy;

  totalRecords: number;
  pagination: PaginationQuery = { pageSize: 6, pageNumber: 1};
  placeholder = 'Enter vacancy name';
  searchString = '';
  suggestField = 'name';

  vacancies: Vacancy[];
  selectedVacancy: Vacancy;

  uId = 0;
  employeeId: number;

  msgs: Message[] = [];

  @ViewChild('p') paginator: Paginator;

  constructor(private vacancyService: VacancyService,
              private authHelper: AuthHelper,
              private invitationService: InvitationService,
              private router: Router,
              private messageService: MessageService,
              private confirmationService: ConfirmationService) {

    this.uId = +this.authHelper.getCurrentUser().id;
  }

  ngOnInit() {

    this.loadVacanciesByRecruiterId();

  }

  loadVacanciesByRecruiterId() {

      this.vacancyService.getFilteredVacancies(this.uId,
        this.searchString,
        this.pagination.pageSize,
        this.pagination.pageNumber)
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

    this.pagination.pageNumber = ++event.page;
    const pageSize = event.rows;

    this.loadVacanciesByRecruiterId();

  }

  vacancyDetails(id: number) {

    this.router.navigate(['/vacancy-details', id]);

  }

  companyDetails(id: number) {

    this.router.navigate(['/company-details', id]);

  }

  confirmDialog(vacancy: Vacancy) {

    this.selectedVacancy = vacancy;

    this.confirmationService.confirm({
        message: 'Are you sure that you want to send this invitation?',
        header: 'Confirmation',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.sendInvitation();
        }
    });
  }

  sendInvitation() {

    const request: InvitationRequest = {
      employeeId: this.employeeId,
      vacancyId: this.selectedVacancy.id
    };

    this.invitationService.create(request)
    .subscribe(data => { this.showSuccess(); });

  }

  showSuccess() {
    this.messageService.add({severity: 'success', summary: 'Success Message', detail: 'Invitation Sent'});
  }

  filterVacancies(event) {
    this.searchString = event.query;
    this.loadVacanciesByRecruiterId();

    if (this.paginator.first !== 0) {
        this.paginator.changePage(0);
    }
}

  select(event) {
    this.searchString = event.name;
    this.vacancies = [];
    this.vacancies[0] = event;
    this.totalRecords = 1;
  }

  clear() {
      this.searchString = '';
      this.loadVacanciesByRecruiterId();
  }
}
