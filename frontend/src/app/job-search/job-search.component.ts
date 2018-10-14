import { Component, OnInit, ViewChild } from '@angular/core';
import { Vacancy } from '../shared/models/vacancy.model';
import { VacancyService } from '../core/services/vacancy.service';
import { Router } from '@angular/router';
import { JobSearchQuery } from '../shared/filterQueries/JobsearchQuery';
import { SearchLineComponent } from '../shared/search-line/search-line.component';
import { Paginator } from 'primeng/paginator';

@Component({
  selector: 'app-job-search',
  templateUrl: './job-search.component.html',
  styleUrls: ['./job-search.component.sass']
})
export class JobSearchComponent implements OnInit {
  
  @ViewChild(SearchLineComponent)
  
  totalRecords: number = 0;
  vacancies: Vacancy[];

  pageSize = 4;
  pageNumber = 1;

  param: JobSearchQuery;


  constructor(private vacancyService: VacancyService, private router: Router) {
    this.vacancies = [];
    this.param = this.getDefaultParam();
  }

  ngOnInit() {
    this.loadVacancies(this.pageSize, this.pageNumber);
  }

  goToVacancyDetails(id: number) {
    this.router.navigate(['/vacancy-details/', id]);
  }

  goToCompanyDetails(id: number) {
    this.router.navigate(['/company-details/', id]);
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
    this.pageSize = event.rows;

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
