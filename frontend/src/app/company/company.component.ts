import { Component, OnInit } from '@angular/core';
import {CompanyService} from '../core/services/company.service';
import { Company } from '../shared/models/company.model';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.sass']
})
export class CompanyComponent implements OnInit {

	company: Company;

  constructor(private companyService : CompanyService) { }

  ngOnInit() {
		this.loadCompany();
  }

	loadCompany(){
    this.companyService.getById(1)
    .subscribe((data:Company)=>this.company=data);
  }
}
