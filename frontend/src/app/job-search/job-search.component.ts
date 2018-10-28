import { Component, OnInit, ViewChild } from '@angular/core';
import { Vacancy } from '../shared/models/vacancy.model';
import { VacancyService } from '../core/services/vacancy.service';
import { ActivatedRoute } from '@angular/router';
import { JobSearchQuery } from '../shared/filterQueries/JobsearchQuery';
import { Paginator } from 'primeng/primeng';
import { PaginationQuery } from '../shared/filterQueries/PaginationQuery';
import { JobFiltersComponent } from '../job-filters/job-filters.component';

@Component({
  selector: 'app-job-search',
  templateUrl: './job-search.component.html',
  styleUrls: ['./job-search.component.sass']
})
export class JobSearchComponent implements OnInit {

  vacancies: Vacancy[];

  totalRecords: number;

  param: JobSearchQuery;
  pagination: PaginationQuery;

  isButtonReset: boolean;

  @ViewChild('p') paginator: Paginator;

  @ViewChild(JobFiltersComponent) jobFilters: JobFiltersComponent;

  constructor(private vacancyService: VacancyService, private route: ActivatedRoute) {
    this.vacancies = [];
    this.param = this.getDefaultParam();

    this.pagination = this.getDefaultPaginationParam();
    this.totalRecords = 0;

    this.isButtonReset = false;

    this.route.queryParams.subscribe(params => {
      this.param.city = params['city'] === undefined ? '' : params['city'];
      this.param.name = params['searchString'] === undefined ? '' : params['searchString'];

      if (params['company'] !== undefined) {
        this.param.namesOfCompanies[0] = params['company'];
      }
    });
  }

  ngOnInit() {
    this.loadVacancies();
  }


  getDefaultParam(): JobSearchQuery {
    return {
      name: '',
      city: '',
      isChecked: false,
      namesOfCompanies: [],
      salary: 0,
      workArea: '',
      typeOfEmployment: ''
    };
  }

  getDefaultPaginationParam(): PaginationQuery {
    return {
      pageSize: 4,
      pageNumber: 1
    };
  }

  getVacanciesByFilter(param: JobSearchQuery) {
    this.param.name = param.name !== null ? param.name : this.param.name;
    this.param.city = param.city !== null ? param.city : this.param.city;
    this.param.workArea = param.workArea !== null ? param.workArea : this.param.workArea;
    this.param.namesOfCompanies = param.namesOfCompanies !== null ? param.namesOfCompanies : this.param.namesOfCompanies;
    this.param.typeOfEmployment = param.typeOfEmployment !== null ? param.typeOfEmployment : this.param.typeOfEmployment;
    this.param.isChecked = param.isChecked !== false ? true : false;
    this.param.salary = param.salary !== null ? param.salary : this.param.salary;

    this.isButtonReset = this.param.namesOfCompanies.length !== 0 || this.param.workArea !== '' ||
                         this.param.typeOfEmployment !== '';

    this.loadVacancies();

    if (this.paginator.first !== 0) {
      this.paginator.changePage(0);
    }
  }

  resetWorkArea() {
    this.jobFilters.resetWorkArea();
    this.jobFilters.filter();
  }

  resetCompany(index: number) {
    const company = this.param.namesOfCompanies[index];

    this.jobFilters.resetCompany(company);
    this.jobFilters.filter();
  }

  resetEmployment() {
    this.jobFilters.resetEmployment();
    this.jobFilters.filter();
  }

  resetAll() {
    this.isButtonReset = false;
    this.jobFilters.resetAll();
  }

  paginate(event) {
    this.pagination = {
      pageNumber: ++event.page,
      pageSize: event.rows
    };

    this.loadVacancies();
  }


  loadVacancies() {
    this.vacancyService.getByFilter(this.param, this.pagination.pageSize, this.pagination.pageNumber)
      .subscribe((response) => {
        this.vacancies = response.body;
        this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
      });
  }
}
