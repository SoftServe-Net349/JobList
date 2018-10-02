import { Component, OnInit } from '@angular/core';
import {CompanyService} from '../core/services/company.service';
import { Company } from '../shared/models/company.model';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.sass']
})
export class CompanyComponent implements OnInit {

  company: Company;

  constructor(
    private companyService: CompanyService,
    private activatedRoute: ActivatedRoute) {
    this.company = {
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

  ngOnInit() {
    this.activatedRoute.params.forEach((params: Params) => {
      const id = +params['id'];
      this.loadCompanyById(id);
    });
  }

  loadCompanyById(id: number) {
    this.companyService.getById(id)
    .subscribe((data: Company) => this.company = data);
  }

  loadRecruiters() {
    console.log('Success');
  }
}
