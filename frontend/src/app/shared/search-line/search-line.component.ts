import { Component, OnInit, Output, EventEmitter } from '@angular/core';

import { CityService } from '../../core/services/city.service';
import { Router } from '@angular/router';
import { City } from '../models/city.model';


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

  @Output() filteredVacancies = new EventEmitter<object>();
  @Output() filteredResumes = new EventEmitter<object>();

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

  search() {
    if (this.currentUrl === '/jobsearch') {
      this.filteredVacancies.emit({
        search: this.inputText === undefined ? '' : this.inputText,
        city: this.selectedCity === undefined || this.selectedCity === null ? '' : this.selectedCity.name});
     } else if (this.currentUrl === '/resumessearch') {
      this.filteredResumes.emit({
        search: this.inputText === undefined ? '' : this.inputText,
        city: this.selectedCity === undefined || this.selectedCity === null ? '' : this.selectedCity.name});
     }
  }

}
