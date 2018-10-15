import { Component, OnInit } from '@angular/core';
import {CompanyService} from '../core/services/company.service';
import { Company } from '../shared/models/company.model';
import { ActivatedRoute, Params } from '@angular/router';
import { Recruiter } from '../shared/models/recruiter.model';
import { RecruiterService } from '../core/services/recruiter.service';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.sass']
})
export class CompanyComponent implements OnInit {

  company: Company;
  recruiters: Recruiter[];

  searchString = '';

  totalRecords = 0;
  pageSize = 4;
  pageNumber = 1;

  constructor(private companyService: CompanyService,
              private recruiterService: RecruiterService,
              private activatedRoute: ActivatedRoute,
              private confirmationService: ConfirmationService) {

    this.company = this.defaultCompany();
    this.recruiters = [];

  }

  defaultCompany(): Company {

    return {
      id: 0,
      name: '',
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
      roleId: 0 };

  }

  ngOnInit() {

    this.activatedRoute.params.forEach((params: Params) => {
      const id = +params['id'];
      this.loadCompanyById(id);
      this.loadRecruiters(id);
    });

  }

  loadCompanyById(id: number = this.company.id) {

    this.companyService.getById(id)
    .subscribe((data: Company) => this.company = data);

  }

  loadRecruiters(id: number = this.company.id,
    pageSize: number = this.pageSize,
    pageNumber: number = this.pageNumber) {

    this.recruiterService.getByCompanyIdWithPagination(id, pageSize, pageNumber)
    .subscribe((response) => {
      this.recruiters = response.body;
      this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
    });

  }

  deleteConfirm(id: number) {

    this.confirmationService.confirm({
        message: 'Do you want to delete this record ?',
        header: 'Delete Confirmation',
        icon: 'pi pi-info-circle',
        accept: () => { this.recruiterService.delete(id).subscribe(data => this.loadRecruiters()); }
    });

  }

  search() {
    if (this.searchString === '') {
      this.loadRecruiters(this.company.id, this.pageSize, this.pageNumber);
    } else {
      this.recruiterService
      .getByCompanyIdSearchStringWithPagination(this.company.id,
                                                this.searchString,
                                                this.pageSize,
                                                this.pageNumber)
        .subscribe((response) => {
          this.recruiters = response.body;
          this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
    });
    }
  }

  paginate(event) {
    this.pageNumber = ++event.page;
    const pageSize = event.rows;

    if (this.searchString === '') {
      this.loadRecruiters(this.company.id, pageSize, this.pageNumber);
    } else {
      this.recruiterService.getByCompanyIdSearchStringWithPagination(this.company.id, this.searchString, pageSize, this.pageNumber)
        .subscribe((response) => {
          this.recruiters = response.body;
          this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
        });
    }
  }

}
