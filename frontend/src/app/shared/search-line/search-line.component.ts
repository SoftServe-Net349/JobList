import { Component, OnInit, Output, EventEmitter } from '@angular/core';

import { CityService } from '../../core/services/city.service';
import { NgForm} from '@angular/forms';
import { VacancyService } from '../../core/services/vacancy.service';


@Component({
  selector: 'app-search-line',
  templateUrl: './search-line.component.html',
  styleUrls: ['./search-line.component.sass'],
  providers: [CityService]
})
export class SearchLineComponent implements OnInit {

  cities: City[];
  selectedCity: City;
  _inputText: String;
  isClicked: Boolean = true;

  @Output() filteredVacancies = new EventEmitter<String>();

  vacancies: Vacancy[];

  constructor(private cityService: CityService, private vacancyService: VacancyService) {
    }

  ngOnInit() {
    this.loadCities();
  }

  loadCities() {
    this.cityService.getAll()
    .subscribe((data: City[]) => this.cities = data);
  }

   submit() {
    this.filteredVacancies.emit(this._inputText);
   }

}
class City {
  name: string;
}

class Vacancy {
  name: string;
}
