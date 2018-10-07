import { Component, OnInit, ViewChild } from '@angular/core';
import { Vacancy } from '../shared/models/vacancy.model';
import { VacancyService } from '../core/services/vacancy.service';
import { SearchLineComponent } from '../shared/search-line/search-line.component';

@Component({
  selector: 'app-job-search',
  templateUrl: './job-search.component.html',
  styleUrls: ['./job-search.component.sass']
})
export class JobSearchComponent implements OnInit {
  @ViewChild(SearchLineComponent)

  totalRecords: number = 0;
  vacancies: Vacancy[];

  pageCount: number = 4;
  pageNumber: number = 1;

  search: string = '';
  city: string = '';

  constructor(private vacancyService: VacancyService) {
    this.vacancies = [];
  }

  ngOnInit() {
      this.loadVacancies(this.pageCount, this.pageNumber);
  }

  getVacanciesBySearchString(param: { search: string, city: string }) {
    this.search = param.search;
    this.city = param.city;

    if (param.search === '' && param.city === '') {
      this.loadVacancies(this.pageCount, this.pageNumber);
    } else {
      // this.paginate({first: 0, page: 0, rows: 4, pageCount: this.pageCount});

      this.vacancyService.getBySearchString(this.search, this.city, this.pageCount, this.pageNumber)
        .subscribe((response) => {
          this.vacancies = response.body;
          this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
        });
    }
  }

  paginate(event) {
    this.pageNumber = event.page + 1;

    if (this.search === '' && this.city === '') {
      this.loadVacancies(event.rows, this.pageNumber);
    } else {
      this.vacancyService.getBySearchString(this.search, this.city, event.rows, this.pageNumber)
        .subscribe((response) => {
          this.vacancies = response.body;
        });
    }
  }

  loadVacancies(pageCount: number, pageNumber: number) {
    this.vacancyService.getFullResponse(pageCount, pageNumber)
      .subscribe((response) => {
        this.vacancies = response.body; 
        this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords; 
    });
  }
}
