import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { CompanyService } from '../core/services/company.service';
import { Company } from '../shared/models/company.model';


@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.sass']
})
export class CompanyDetailsComponent implements OnInit {

  company: Company;

  constructor(private activatedRoute: ActivatedRoute, private companyService: CompanyService) {
  }

  ngOnInit() {
    this.activatedRoute.params.forEach((params: Params) => {
      const id = +params['id'];
      this.loadCompanyById(id);
    });
  }


  loadCompanyById(id: number = this.company.id) {
    this.companyService.getById(id)
    .subscribe((data: Company) => this.company = data);
  }

}
