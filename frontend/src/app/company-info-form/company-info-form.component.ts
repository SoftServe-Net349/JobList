import { Component, OnInit } from '@angular/core';
import { Company } from '../shared/models/company.model';

@Component({
  selector: 'app-company-info-form',
  templateUrl: './company-info-form.component.html',
  styleUrls: ['./company-info-form.component.sass']
})
export class CompanyInfoFormComponent implements OnInit {

  display: Boolean = false;
  action: String;

  company: Company;

  constructor() {
    this.company = this.defaultCompany();
  }

  ngOnInit() {
  }

  defaultCompany(): Company {
    return {
      id: 0, name: '',
      bossName: '',
      fullDescription: '',
      shortDescription: '',
      address: '',
      phone: '',
      logoData: [],
      logoMimetype: '',
      site: '',
      email: '',
      password: '',
      role: {id: 1, name: ''},
      recruiters: []
    };
  }

  showInformationForm(action: String, company: Company = this.defaultCompany()) {
    this.company = company;
    this.display = true;
    this.action = action;
 }

}
