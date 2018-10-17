import { CanActivate, Router } from '@angular/router';

import { Injectable } from '@angular/core';


import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthHelper } from '../../shared/helpers/auth-helper';
import { Observable } from 'rxjs';

@Injectable()

export class RecruiterGuard implements CanActivate {

  constructor(private router: Router, private authHelper: AuthHelper) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {

    const currentPerson = this.authHelper.getCurrentPerson();

    if (currentPerson === null) {

      this.router.navigate(['/']);
      return false;

    }

    if (currentPerson.role === 'recruiter'  && route.params['id'] === currentPerson.id) {

      return true;

    } else {

      this.router.navigate(['/']);
      return false;

    }

  }

}
