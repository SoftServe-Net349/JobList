import { Component, OnInit } from '@angular/core';
import {SelectItem} from 'primeng/api';


@Component({
  selector: 'app-search-line',
  templateUrl: './search-line.component.html',
  styleUrls: ['./search-line.component.sass']
})
export class SearchLineComponent implements OnInit {

  cities: SelectItem[];
  selectedCar: string;

  constructor() { //SelectItem API with label-value pairs
    this.cities = [
      {label: 'Lviv', value: 'Lviv'},
      {label: 'Kyiv', value: 'Kyiv'},
      {label: 'I-F', value: 'I-F'}
      ];
    }

  ngOnInit() {
  }

}
