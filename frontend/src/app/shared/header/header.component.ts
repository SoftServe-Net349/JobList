import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Company } from '../models/company.model';
import { MenuItem } from 'primeng/api';
import { CompanyInfoFormComponent } from '../../company-info-form/company-info-form.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.sass']
})
export class HeaderComponent implements OnInit {
  indx: String;

  visibleForCompany;
  itemsForCompany: MenuItem[];

  visibleForRecruiter;
  itemsForRecruiter: MenuItem[];

  visibleForUser;
  itemsForUser: MenuItem[];

  constructor(private router: Router) {
    console.log(router.url);
    this.indx = router.url.substr(-1);
   }

   @Input()
   company: Company;
   @Input()
   companyInfoForm: CompanyInfoFormComponent;

   ngOnInit() {
     if (this.router.url === '/companies/' + this.indx) {
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
     ]; } else if (this.router.url === '/recruiter' || this.router.url === '/recruiter/+indx' || this.router.url === '/resumessearch') {
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
        ]; } else if (this.router.url === '/user' || this.router.url === '/jobsearch') {
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
}
