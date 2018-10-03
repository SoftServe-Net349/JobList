import { Component, OnInit } from '@angular/core';
import { Vacancy } from '../shared/models/vacancy.model';
import { VacancyService } from '../core/services/vacancy.service';

@Component({
  selector: 'app-job-search',
  templateUrl: './job-search.component.html',
  styleUrls: ['./job-search.component.sass']
})
export class JobSearchComponent implements OnInit {

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

}
