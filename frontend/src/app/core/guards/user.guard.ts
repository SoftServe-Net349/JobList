import { CanActivate, Router } from '@angular/router';

import { Injectable } from '@angular/core';


import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthHelper } from '../../shared/helpers/auth-helper';
import { Observable } from 'rxjs';
import { Person } from '../../shared/models/person.model';

@Injectable()

export class UserGuard implements CanActivate {

  constructor(private router: Router, private authHelper: AuthHelper) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {

    const currentPerson = this.authHelper.getCurrentPerson();

    if (currentPerson === null) {

      this.router.navigate(['/']);
      return false;

    }
    if (currentPerson.role === 'user' && route.params['id'] === currentPerson.id) {

      return true;

    } else {

      this.router.navigate(['/']);
      return false;

    }

  }

}
