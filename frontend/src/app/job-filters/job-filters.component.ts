import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-job-filters',
  templateUrl: './job-filters.component.html',
  styleUrls: ['./job-filters.component.sass']
})

export class JobFiltersComponent implements OnInit {

  checked: Boolean = false;

  cities: City[];
  selectedCity: City;

  companies: Company[];
  selectedCompany: Company;

  constructor() {
    this.companies = [
      {name: 'SoftServe'},
      {name: 'epam'},
      {name: 'eleks'},
      {name: 'Global Logic'},
      {name: 'Inter Logic'}
    ];
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

}

class City {
  name: string;
  code: string;

}

class Company {
  name: string;

}
