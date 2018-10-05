import { Component, OnInit } from '@angular/core';
import { CityService } from '../../core/services/city.service';
import { VacancyService } from '../../core/services/vacancy.service';
import { Vacancy } from '../../shared/models/vacancy.model';
import { City } from '../../shared/models/city.model';

@Component({
  selector: 'app-main-search',
  templateUrl: './main-search.component.html',
  styleUrls: ['./main-search.component.sass'],
  providers: [CityService]
})

export class MainSearchComponent implements OnInit {

  cities: City[];
  selectedCity: City;

  vacancies: Vacancy[];

  constructor(private cityService: CityService,
              private vacancyService: VacancyService) {

    this.vacancies = [];
  }

  ngOnInit() {
    this.loadCities();
    this.loadVacancies();
  }

  loadCities() {
      this.cityService.getAll()
      .subscribe((data: City[]) => this.cities = data);
    }

  loadVacancies() {
      this.vacancyService.getAll()
      .subscribe((data: Vacancy[]) => this.vacancies = data);
   }
}
