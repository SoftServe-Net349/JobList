import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
    this.activeRoute.params.subscribe( params => this.index = params.id );
   }

   @Input()
   company: Company;
   @Input()
   companyInfoForm: CompanyInfoFormComponent;

   ngOnInit() {
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
          {label: 'Something1', icon: 'pi pi-fw pi-user-plus'},
          {label: 'Something2', icon: 'pi pi-fw pi-filter'}
          ]
        },
        {
        label: 'Sign out',
        icon: 'fa fa-sign-out'
        }
        ]; } else if (this.isUserHeader()) {
          this.itemsForUser = [
            {
              label: 'Find Vacancies',
              icon: 'fa fa-search-plus'
            },
            {
              label: 'Settings',
              icon: 'fa fa-cog',
              items: [
                {label: 'Change password', icon: 'pi pi-fw pi-user-plus'},
                {label: 'Change login', icon: 'pi pi-fw pi-filter'}
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
     || this.router.url === '/resume-details';
   }
   isUserHeader() {
     return this.router.url === '/users/' + this.index || this.router.url === '/jobsearch' || this.router.url === '/vacancy-details'
     || this.router.url === '/company-details';
   }
}
