import { Component, OnInit } from '@angular/core';
//import { City } from '../models/city.model'
import { CityService } from '../../core/services/city.service';
import { NgForm} from '@angular/forms';


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

  constructor(private cityService:CityService) {
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
  }
 
}
class City {
name: string;
}