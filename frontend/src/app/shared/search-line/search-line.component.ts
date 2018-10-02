import { Component, OnInit, Output, EventEmitter } from '@angular/core';

import { CityService } from '../../core/services/city.service';
import { NgForm} from '@angular/forms';
import { VacancyService } from '../../core/services/vacancy.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-search-line',
  templateUrl: './search-line.component.html',
  styleUrls: ['./search-line.component.sass'],
  providers: [CityService]
})
export class SearchLineComponent implements OnInit {

  cities: City[];
  selectedCity: City;
  inputText: String;

  @Output() filteredVacancies = new EventEmitter<String>();
  @Output() filteredResumes = new EventEmitter<String>();

  currentUrl: String;
  constructor(private cityService: CityService, router: Router) {
  this.currentUrl = router.url;
  }

  ngOnInit() {
    this.loadCities();
  }

  loadCities() {
    this.cityService.getAll()
    .subscribe((data: City[]) => this.cities = data);
  }


 submit() {
   if (this.currentUrl === '/jobsearch') {
    this.filteredVacancies.emit(this.inputText);
   } else if (this.currentUrl === '/resumessearch') {
    this.filteredResumes.emit(this.inputText);
   }
  }
}
class City {
  name: string;
}

class Vacancy {
  name: string;
}
