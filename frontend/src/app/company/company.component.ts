import { Component, OnInit, ViewChild } from '@angular/core';
import {CompanyService} from '../core/services/company.service';
import { Company } from '../shared/models/company.model';
import { ActivatedRoute, Params } from '@angular/router';
import { Recruiter } from '../shared/models/recruiter.model';
import { RecruiterService } from '../core/services/recruiter.service';
import { ConfirmationService } from 'primeng/api';
import { Paginator } from 'primeng/paginator';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

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

  @ViewChild('recruitersPaginator')
  recruitersPaginator: Paginator;

  constructor(private companyService: CompanyService,
              private recruiterService: RecruiterService,
              private activatedRoute: ActivatedRoute,
              private confirmationService: ConfirmationService,
              private _sanitizer: DomSanitizer) {

  }

  ngOnInit() {

    this.activatedRoute.params.forEach((params: Params) => {
      const id = +params['id'];
      this.loadCompanyById(id);
      this.loadRecruiters(id);
    });

  }

  console() {
    console.log(this.company);
  }
  loadCompanyById(id: number = this.company.id) {

    this.companyService.getById(id)
    .subscribe((data: Company) => { this.company = data; });

  }

  loadRecruiters(id: number = this.company.id,
    pageSize: number = this.pageSize,
    pageNumber: number = this.pageNumber) {

    this.recruiterService.getByCompanyIdWithPagination(id, pageSize, pageNumber)
    .subscribe((response) => {
      this.recruiters = response.body;
      const XPagination = JSON.parse(response.headers.get('X-Pagination'));

      if (XPagination !== null) {
        this.totalRecords = XPagination.TotalRecords;
      }
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
    this.pageNumber = 1;
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

        const XPagination = JSON.parse(response.headers.get('X-Pagination'));

        if (XPagination !== null) {
          this.totalRecords = XPagination.TotalRecords;
        }

        this.recruitersPaginator.changePage(0);
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

          const XPagination = JSON.parse(response.headers.get('X-Pagination'));

          if (XPagination !== null) {
            this.totalRecords = XPagination.TotalRecords;
          }
      });
    }
  }

  sanitizeCompanyImg(imageBase64): SafeUrl {
    if (this.company !== undefined && this.company.logoData !== undefined &&
        this.company.logoData !== null && this.company.logoData !== '') {

      return this._sanitizer.bypassSecurityTrustUrl(`data:image/${this.company.logoMimetype};base64,` + imageBase64);

    } else {

      return '../../images/yourLogoHere.png';

    }
  }

  sanitizeRecruiterImg(imageBase64, recruiter: Recruiter): SafeUrl {
    if (this.recruiters !== undefined && recruiter.photoData !== undefined &&
          recruiter.photoData !== null && recruiter.photoData !== '') {

      return this._sanitizer.bypassSecurityTrustUrl(`data:image/${recruiter.photoMimetype};base64,` + imageBase64);

    } else {

      return '../../images/defaultUser.png';

    }
  }
}
