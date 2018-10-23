import { Component, OnInit, ViewChild } from '@angular/core';
import { Vacancy } from '../shared/models/vacancy.model';
import { VacancyService } from '../core/services/vacancy.service';
import {  ActivatedRoute } from '@angular/router';
import { JobSearchQuery } from '../shared/filterQueries/JobsearchQuery';
import { Paginator } from 'primeng/primeng';

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

  url: string;

  @ViewChild('p') paginator: Paginator;


  constructor(private vacancyService: VacancyService, private route: ActivatedRoute) {
    this.vacancies = [];
    this.param = this.getDefaultParam();

    this.route.queryParams.subscribe(params => {
      this.param.city = params['city'] === undefined ? '' : params['city'];
      this.param.name = params['searchString'] === undefined ? '' : params['searchString'];
      this.param.namesOfCompanies[0] = params['company'] === undefined ? '' : params['company'];
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

  getVacanciesByFilter(param: JobSearchQuery) {
    this.param.name = param.name !== null ? param.name : this.param.name;
    this.param.city = param.city !== null ? param.city : this.param.city;
    this.param.workArea = param.workArea !== null ? param.workArea : this.param.workArea;
    this.param.namesOfCompanies = param.namesOfCompanies !== null ? param.namesOfCompanies : this.param.namesOfCompanies;
    this.param.typeOfEmployment = param.typeOfEmployment !== null ? param.typeOfEmployment : this.param.typeOfEmployment;
    this.param.isChecked = param.isChecked !== false ? true : false;
    this.param.salary = param.salary !== null ? param.salary : this.param.salary;

    this.loadVacancies();

    this.paginator.changePage(0);
  }

  paginate(event) {
    this.pageNumber = event.page + 1;
    this.pageSize = event.rows;

    this.loadVacancies();
  }


  loadVacancies() {
    this.vacancyService.getByFilter(this.param, this.pageSize, this.pageNumber)
      .subscribe((response) => {
        this.vacancies = response.body;
        this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
      });
  }
}
