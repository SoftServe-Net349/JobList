import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { Company } from '../models/company.model';
import { MenuItem } from 'primeng/api';
import { CompanyInfoFormComponent } from '../../company-info-form/company-info-form.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.sass']
})
export class HeaderComponent implements OnInit {
  index: string;
  visibleForCompany;
  itemsForCompany: MenuItem[];

  visibleForRecruiter;
  itemsForRecruiter: MenuItem[];

  visibleForUser;
  itemsForUser: MenuItem[];

  constructor(private activeRoute: ActivatedRoute,
              private router: Router) {

   }

   @Input()
   company: Company;
   @Input()
   companyInfoForm: CompanyInfoFormComponent;

   ngOnInit() {
    this.activeRoute.params.forEach( (params: Params) =>  this.index = params.id);

    if (this.isCompanyHeader()) {
    this.itemsForCompany = [
      {
        label: 'Home',
        icon: 'fa fa-home'
      },
      {
        label: 'Settings',
        icon: 'fa fa-cog',
        items: [
          {label: 'Change password', icon: 'fa fa-pencil-square-o'}
        ]
      },
      {
      label: 'Sign out',
      icon: 'fa fa-sign-out'
      }
    ]; } else if (this.isRecruiterHeader()) {
    this.itemsForRecruiter = [
      {
        label: 'Home',
        icon: 'fa fa-home'
      },
      {
        label: 'Settings',
        icon: 'fa fa-cog',
        items: [
          {label: 'Change password', icon: 'fa fa-pencil-square-o'}
        ]
      },
      {
      label: 'Sign out',
      icon: 'fa fa-sign-out'
      }
      ]; } else if (this.isUserHeader()) {
        this.itemsForUser = [
          {
            label: 'Home',
            icon: 'fa fa-home'
          },
          {
            label: 'Settings',
            icon: 'fa fa-cog',
            items: [
              {label: 'Change password', icon: 'fa fa-pencil-square-o'}
            ]
          },
          {
          label: 'Sign out',
          icon: 'fa fa-sign-out'
          }
        ];
      }
   }
   isHomeHeader() {
     return this.router.url === '/';
   }
   isCompanyHeader() {
    return this.router.url === '/companies/' + this.index;
   }
   isRecruiterHeader() {
    return this.router.url === '/recruiters/' + this.index || this.router.url === '/resumessearch'
     || this.router.url === '/resume-details/' + this.index;
   }
   isUserHeader() {
     return this.router.url === '/users/' + this.index
     || this.router.url === '/jobsearch'
     || this.router.url === '/vacancy-details/' + this.index
     || this.router.url === '/company-details/' + this.index;
   }
}
