import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-job-filters',
  templateUrl: './job-filters.component.html',
  styleUrls: ['./job-filters.component.sass']
})

export class JobFiltersComponent implements OnInit {

  checked: Boolean = false;

  workAreas: WorkArea[];
  selectedWorkArea: WorkArea;

  cities: City[];
  selectedCity: City;

  companies: Company[];
  selectedCompanies: Company[];

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
    this.workAreas = [
      {name: 'Software developer'},
      {name: 'Builder'},
      {name: 'Teacher'},
      {name: 'Doctor'},
      {name: 'Software developer'},
      {name: 'Builder'},
      {name: 'Teacher'},
      {name: 'Doctor'},
      {name: 'Software developer'},
      {name: 'Builder'},
      {name: 'Teacher'},
      {name: 'Doctor'},
      {name: 'Software developer'},
      {name: 'Builder'},
      {name: 'Teacher'},
      {name: 'Doctor'},
      {name: 'Software developer'},
      {name: 'Builder'},
      {name: 'Teacher'},
      {name: 'Doctor'},
      {name: 'Software developer'},
      {name: 'Builder'},
      {name: 'Teacher'},
      {name: 'Doctor'},
      {name: 'Software developer'},
      {name: 'Builder'},
      {name: 'Teacher'},
      {name: 'Doctor'},
      {name: 'Software developer'},
      {name: 'Builder'},
      {name: 'Teacher'},
      {name: 'Doctor'},
      {name: 'Software developer'},
      {name: 'Builder'},
      {name: 'Teacher'},
      {name: 'Doctor'},
      {name: 'Driver'}
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

class WorkArea {
  name: string;

}
