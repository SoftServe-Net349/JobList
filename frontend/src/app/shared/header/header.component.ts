import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { AuthorizationsComponent } from '../../authorizations/authorizations.component';
import { AuthHelper } from '../helpers/auth-helper';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from '../../core/services/auth.service';
import { ResetPasswordComponent } from 'src/app/reset-password/reset-password.component';


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

  visibleForEmployee = false;
  itemsForEmployee: MenuItem[];

  signInItems: MenuItem[];

  @ViewChild(AuthorizationsComponent)
  authorizations: AuthorizationsComponent;
  @ViewChild(ResetPasswordComponent)
  resetPassword: ResetPasswordComponent;


  constructor(private activeRoute: ActivatedRoute,
              private router: Router,
              private authHelper: AuthHelper,
              private jwtHelper: JwtHelperService,
              private authService: AuthService) {}

  ngOnInit() {

    this.activeRoute.params.forEach( (params: Params) =>  this.index = params.id);

    this.signInItems = [
      {label: 'Sign In as Employee', icon: 'fa fa-user', command: (event) => { this.authorizations.showSignIn('Employee'); }},
      {label: 'Sign In as Company', icon: 'fa fa-building', command: (event) => { this.authorizations.showSignIn('Company'); }},
      {label: 'Sign In as Recruiter', icon: 'fa fa-user-circle-o', command: (event) => { this.authorizations.showSignIn('Recruiter'); }}
    ];

    this.itemsForCompany = this.getItemsForCompany();
    this.itemsForRecruiter = this.getItemsForRecruiter();
    this.itemsForEmployee = this.getItemsForEmployee();

    this.chengeAuthenticatedStatus();

  }

  getItemsForCompany(): MenuItem[] {

     return [
      {
        label: 'Home',
        icon: 'fa fa-home',
        command: (event) => {this.router.navigate(['/companies', this.uId]); }
      },
      {
        label: 'Settings',
        icon: 'fa fa-cog',
        items: [
          {label: 'Change password', icon: 'fa fa-pencil-square-o',
          command: (event) => {this.resetPassword.showResetPassword(this.role, this.uId);}}
        ]
      },
      {
      label: 'Sign out',
      icon: 'fa fa-sign-out',
      command: (event) => { this.authHelper.logout(); this.authService.logout(); this.chengeAuthenticatedStatus(); }
      }
    ];

  }

  getItemsForRecruiter(): MenuItem[] {

    return [
      {
        label: 'Home',
        icon: 'fa fa-home',
        command: (event) => { this.router.navigate(['/recruiters', this.uId]); }
      },
      {
        label: 'Settings',
        icon: 'fa fa-cog',
        items: [
          {label: 'Change password', icon: 'fa fa-pencil-square-o',
          command: (event) => {this.resetPassword.showResetPassword(this.role, this.uId);}}
        ]
      },
      {
      label: 'Sign out',
      icon: 'fa fa-sign-out',
      command: (event) => { this.authHelper.logout(); this.router.navigate(['/']); this.chengeAuthenticatedStatus(); }
      }
    ];

  }

  getItemsForEmployee(): MenuItem[] {

    return [
      {
        label: 'Home',
        icon: 'fa fa-home',
        command: (event) => { this.router.navigate(['/employees', this.uId]); }
      },
      {
        label: 'Settings',
        icon: 'fa fa-cog',
        items: [
          {label: 'Change password', icon: 'fa fa-pencil-square-o',
          command: (event) => {this.resetPassword.showResetPassword(this.role, this.uId);}}
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
      this.uId = decodeToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];

    } else {

      this.role = '';
      this.uId = 0;

    }
  }

}
