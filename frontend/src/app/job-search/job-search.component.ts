import { Component, OnInit, ViewChild } from '@angular/core';
import { Vacancy } from '../shared/models/vacancy.model';
import { VacancyService } from '../core/services/vacancy.service';
import { JobSearchQuery } from '../shared/filterQueries/JobsearchQuery';

@Component({
  selector: 'app-job-search',
  templateUrl: './job-search.component.html',
  styleUrls: ['./job-search.component.sass']
})
export class JobSearchComponent implements OnInit {

  totalRecords = 0;
  vacancies: Vacancy[];

  pageSize = 4;
  pageNumber = 1;

  param: JobSearchQuery;


  constructor(private vacancyService: VacancyService) {
    this.vacancies = [];
    this.param = this.getDefaultParam();
  }

  ngOnInit() {
    this.loadVacancies(this.pageSize, this.pageNumber);
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

  getVacanciesByFilter(param: JobSearchQuery) {
    this.param.name = param.name !== null ? param.name : this.param.name;
    this.param.city = param.city !== null ? param.city : this.param.city;
    this.param.workArea = param.workArea !== null ? param.workArea : this.param.workArea;
    this.param.namesOfCompanies = param.namesOfCompanies !== null ? param.namesOfCompanies : this.param.namesOfCompanies;
    this.param.typeOfEmployment = param.typeOfEmployment !== null ? param.typeOfEmployment : this.param.typeOfEmployment;
    this.param.isChecked = param.isChecked !== false ? true : false;
    this.param.salary = param.salary !== null ? param.salary : this.param.salary;
    if (param === this.getDefaultParam()) {
      this.loadVacancies(this.pageSize, this.pageNumber);
    } else {
      this.vacancyService.getByFilter(this.param, this.pageSize, this.pageNumber)
        .subscribe((response) => {
          this.vacancies = response.body;
          this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
        });
    }
  }

  paginate(event) {
    this.pageNumber = event.page + 1;

    if (this.param === this.getDefaultParam()) {
      this.loadVacancies(event.rows, this.pageNumber);
    } else {
      this.vacancyService.getByFilter(this.param, event.rows, this.pageNumber)
        .subscribe((response) => {
          this.vacancies = response.body;
        });
    }
  }

  loadVacancies(pageSize: number, pageNumber: number) {
    this.vacancyService.getFullResponse(pageSize, pageNumber)
      .subscribe((response) => {
        this.vacancies = response.body;
        this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
      });
  }
}
