import { Component, OnInit, ViewChild } from '@angular/core';
import { Recruiter } from '../shared/models/recruiter.model';
import { ConfirmationService } from 'primeng/api';
import { RecruiterService } from '../core/services/recruiter.service';
import { ActivatedRoute, Params } from '@angular/router';
import { VacancyService } from '../core/services/vacancy.service';
import { Vacancy } from '../shared/models/vacancy.model';
import { Paginator } from 'primeng/paginator';




@Component({
  selector: 'app-recruiter',
  templateUrl: './recruiter.component.html',
  styleUrls: ['./recruiter.component.sass']
})
export class RecruiterComponent implements OnInit {

  display: Boolean = false;
  action: String;

  searchString = '';

  totalRecords = 0;
  pageSize = 4;
  pageNumber = 1;
  vacancies: Vacancy[];

  recruiter: Recruiter;

  @ViewChild('p') vacanciesPaginator: Paginator;

  constructor(
    private confirmationService: ConfirmationService,
    private recruiterService: RecruiterService,
    private vacancyService: VacancyService,
    private activatedRoute: ActivatedRoute) {

    }


  ngOnInit() {
    this.activatedRoute.params.forEach((params: Params) => {
      const id = +params['id'];
      this.loadRecruiterById(id);
      this.loadVacancies(id);
    });
  }

  loadRecruiterById(id: number) {
    this.recruiterService.getById(id)
    .subscribe((data: Recruiter) => this.recruiter = data);
  }

  loadVacancies(id: number = this.recruiter.id,
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
  

  deleteConfirm(id: number) {
    this.confirmationService.confirm({
        message: 'Do you want to delete this record?',
        header: 'Delete Confirmation',
        icon: 'pi pi-info-circle',
        accept: () => { this.vacancyService.delete(id).subscribe(data => this.loadVacancies());
      }
    });
  }
  search() {
    this.pageNumber = 1;
    if (this.searchString === '') {
      this.loadVacancies(this.recruiter.id, this.pageSize, this.pageNumber);
    } else {
      this.vacancyService
      .getByRecruiterIdSearchStringWithPagination(this.recruiter.id,
                                                this.searchString,
                                                this.pageSize,
                                                this.pageNumber)
      .subscribe((response) => {
        this.vacancies = response.body;

        const XPagination = JSON.parse(response.headers.get('X-Pagination'));

        if (XPagination !== null) {
          this.totalRecords = XPagination.TotalRecords;
        }

        this.vacanciesPaginator.changePage(0);
      });
    }
  }

  paginate(event) {
    this.pageNumber = ++event.page;
    const pageSize = event.rows;

    if (this.searchString === '') {
      this.loadVacancies(this.recruiter.id, pageSize, this.pageNumber);
    } else {
      this.vacancyService.getByRecruiterIdSearchStringWithPagination(this.recruiter.id, this.searchString, pageSize, this.pageNumber)
        .subscribe((response) => {
          this.vacancies = response.body;

          const XPagination = JSON.parse(response.headers.get('X-Pagination'));

          if (XPagination !== null) {
            this.totalRecords = XPagination.TotalRecords;
          }
      });
    }
  }
}
