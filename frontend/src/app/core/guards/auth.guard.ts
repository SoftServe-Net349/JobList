import { CanActivate, Router } from '@angular/router';

import { Injectable } from '@angular/core';


import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthHelper } from '../../shared/helpers/auth-helper';
import { Observable } from 'rxjs';

@Injectable()

export class AuthGuard implements CanActivate {

  constructor(private router: Router, private authHelper: AuthHelper) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {

    if (!this.authHelper.isAuthenticated()) {

      this.router.navigate(['/']);

      return false;

    }

    return true;

  }

}
