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

  constructor(private companyService : CompanyService) { 
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
		this.loadCompany();
  }

	loadCompany(){
    this.companyService.getById(1)
    .subscribe((data:Company)=>this.company=data);
  }
}
