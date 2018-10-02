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
  private searchLine: SearchLineComponent;

  vacancies: Vacancy[];
  constructor(private vacancyService: VacancyService) {
    this.vacancies = [];
   }

  ngOnInit() {
    this.loadVacancis();
  }

  loadVacancis() {
    this.vacancyService.getAll()
    .subscribe((data: Vacancy[]) => this.vacancies = data);
  }

  getVacanciesBySearchString(searchString: String) {
    if (searchString === '') {
      this.loadVacancis();
    } else {
      this.vacancyService.getBySearchString(searchString)
      .subscribe((data: Vacancy[]) => this.vacancies = data);
    }
  }
}
