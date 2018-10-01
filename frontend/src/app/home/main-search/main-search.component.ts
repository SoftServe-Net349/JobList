import { Component, OnInit } from '@angular/core';
import { CityService } from '../../core/services/city.service';

@Component({
  selector: 'app-main-search',
  templateUrl: './main-search.component.html',
  styleUrls: ['./main-search.component.sass'],
  providers: [CityService]
})

export class MainSearchComponent implements OnInit {
 
  cities: City[];
  selectedCity: City;
  constructor(private cityService:CityService) { 
   
  }
  ngOnInit() {
    this.loadCities();
  }
  //handleClick() {}
  
  loadCities(){
      this.cityService.getAll()
      .subscribe((data: City[]) => this.cities = data);
    }

   
}
class City {
  name: string;
}