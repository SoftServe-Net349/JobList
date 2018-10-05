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
    this.loadVacancies();
  }

  loadVacancies() {
    this.vacancyService.getAll()
    .subscribe((data: Vacancy[]) => this.vacancies = data);
  }

  getVacanciesBySearchString(param: {search: string, city: string}) {
    if (param.search === '' && param.city === '') {
      this.loadVacancies();
    } else {
      this.vacancyService.getBySearchString(param.search, param.city)
      .subscribe((data: Vacancy[]) => this.vacancies = data);
    }
  }

}
