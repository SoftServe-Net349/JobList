import { Component, OnInit, ViewChild  } from '@angular/core';
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

  vacancies: Vacancy[];
  constructor(private vacancyService: VacancyService) {
    this.vacancies = [];
   }

  ngOnInit() {
    this.loadVacancis(4, 1);
  }

  loadVacancis(pageCount: number, pageNumber: number) {
    this.vacancyService.getAll(pageCount, pageNumber)
    .subscribe((data: Vacancy[]) => this.vacancies = data);
  }

  getVacanciesBySearchString(searchString: String) {
    if (searchString === '') {
      this.loadVacancis(4, 1);
    } else {
      this.vacancyService.getBySearchString(searchString, 4, 1)
      .subscribe((data: Vacancy[]) => this.vacancies = data);
    }
  }

  paginate(event){
    this.vacancyService.getAll(event.rows, event.page + 1)
      .subscribe((data: Vacancy[]) => this.vacancies = data);
  }
}
