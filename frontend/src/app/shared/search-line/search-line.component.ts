import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

import { CityService } from '../../core/services/city.service';
import { Router } from '@angular/router';
import { City } from '../models/city.model';
import { JobSearchQuery } from '../filterQueries/JobsearchQuery';
import { isNullOrUndefined } from 'util';


@Component({
  selector: 'app-search-line',
  templateUrl: './search-line.component.html',
  styleUrls: ['./search-line.component.sass'],
  providers: [CityService]
})
export class SearchLineComponent implements OnInit {

  cities: City[];
  selectedCity: City;
  inputText: string;

  @Output() foundVacancies = new EventEmitter<JobSearchQuery>();
  @Output() filteredResumes = new EventEmitter<object>();

  currentUrl: String;

  @Input() searchString: string;
  @Input() cityName: string;

  constructor(private cityService: CityService, router: Router) {
    this.currentUrl = router.url;
  }

  ngOnInit() {
    this.loadCities();

    this.inputText = this.searchString;
  }

  loadCities() {
    this.cityService.getAll()
      .subscribe((data: City[]) => {
        this.cities = data;
        if (!isNullOrUndefined(this.cityName)) {
          this.selectedCity = this.cities.find(c => c.name === this.cityName);
        }
      });
  }

  search() {
    if (this.currentUrl === '/jobsearch') {
      this.foundVacancies.emit({
        workArea: null,
        namesOfCompanies: null,
        typeOfEmployment: null,
        isChecked: false,
        salary: null,
        name: this.inputText === undefined ? '' : this.inputText,
        city: this.selectedCity === undefined || this.selectedCity === null ? '' : this.selectedCity.name
      });
    } else if (this.currentUrl === '/resumessearch') {
      this.filteredResumes.emit({
        name: this.inputText === undefined ? '' : this.inputText,
        city: this.selectedCity === undefined || this.selectedCity === null ? '' : this.selectedCity.name
      });
    }
  }

}
