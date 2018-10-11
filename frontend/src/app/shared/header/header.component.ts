import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { Company } from '../models/company.model';
import { MenuItem } from 'primeng/api';
import { CompanyInfoFormComponent } from '../../company-info-form/company-info-form.component';
import { AuthorizationsComponent } from '../../authorizations/authorizations.component';
import { AuthHelper } from '../helpers/auth-helper';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.sass']
})
export class HeaderComponent implements OnInit {

  index: string;
  role = '';
  uId = 0;

  visibleForCompany = false;
  itemsForCompany: MenuItem[];

  visibleForRecruiter = false;
  itemsForRecruiter: MenuItem[];

  visibleForUser = false;
  itemsForUser: MenuItem[];

  signInItems: MenuItem[];

  @Input()
  company: Company;
  @Input()
  companyInfoForm: CompanyInfoFormComponent;

  @ViewChild(AuthorizationsComponent)
  authorizations: AuthorizationsComponent;


  constructor(private activeRoute: ActivatedRoute,
              private router: Router,
              private authHelper: AuthHelper,
              private jwtHelper: JwtHelperService) {

  }

  ngOnInit() {
    this.activeRoute.params.forEach( (params: Params) =>  this.index = params.id);

    this.signInItems = [
      {label: 'SignIn for User', icon: 'fa fa-user', command: (event) => { this.authorizations.showSignIn('User'); }},
      {label: 'SignIn for Company', icon: 'fa fa-building', command: (event) => { this.authorizations.showSignIn('Company'); }},
      {label: 'SignIn for Recruiter', icon: 'fa fa-user-circle-o', command: (event) => { this.authorizations.showSignIn('Recruiter'); }}
    ];

    this.itemsForCompany = this.getItemsForCompany();
    this.itemsForRecruiter = this.getItemsForRecruiter();
    this.itemsForUser = this.getItemsForUser();

    this.chengeAuthenticatedStatus();
  }

  getItemsForCompany(): MenuItem[] {
     return [
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

  getItemsForRecruiter(): MenuItem[] {
    return [
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

  getItemsForUser(): MenuItem[] {
    return [
      {
        label: 'Home',
        icon: 'fa fa-home',
        command: (event) => { this.router.navigate(['/users', this.uId]); }
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
      icon: 'fa fa-sign-out',
      command: (event) => { this.authHelper.logout(); this.router.navigate(['/']); this.chengeAuthenticatedStatus(); }
      }
    ];
  }

  chengeAuthenticatedStatus() {
    if (this.authHelper.isAuthenticated()) {
      const token = this.authHelper.getToken();
      const decodeToken = this.jwtHelper.decodeToken(token);
      this.role = decodeToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      this.uId = decodeToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
    } else {
      this.role = '';
      this.uId = 0;
    }

  }

}
