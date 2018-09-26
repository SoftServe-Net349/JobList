import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vacancy-form',
  templateUrl: './vacancy-form.component.html',
  styleUrls: ['./vacancy-form.component.sass']
})
export class VacancyFormComponent implements OnInit {

	display: Boolean = false;
	action: String;
  
	cities: City[];
	selectedCity: City;
  
	constructor() {
		this.cities = [
			{name: 'New York', code: 'NY'},
			{name: 'Rome', code: 'RM'},
			{name: 'London', code: 'LDN'},
			{name: 'Istanbul', code: 'IST'},
			{name: 'Paris', code: 'PRS'}
		  ];	  
	 }
  
	ngOnInit() {
	}
  
	showVacancyForm(action: String) {
	this.display = true;
	this.action = action;
	}
  
}

class City {
	name: string;
	code: string;
  
  }
  