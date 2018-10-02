import { Component, OnInit } from '@angular/core';
//import { City } from '../models/city.model'
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
  _inputText:string;

  vacancies: Vacancy[];

  constructor(private cityService:CityService, private vacancyService: VacancyService) {
    }

  ngOnInit() {
    this.loadCities();
  }

  loadCities(){
    this.cityService.getAll()
    .subscribe((data: City[]) => this.cities = data);
  }

  submit(str)
  {
    this._inputText = str;
    this.getVacanciesBySearchString(this._inputText);
  }

  getVacanciesBySearchString(searchString: string){
    this.vacancyService.getBySearchString(searchString)
    .subscribe((data: Vacancy[]) => this.vacancies = data);
  }
 
}
class City {
  name: string;
}

class Vacancy{
  name: string;
}