import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {throwError as observableThrowError,  Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { TokenService } from '../services/token.service';
import { AuthHelper } from '../../shared/helpers/auth-helper';
import { switchMap, catchError, finalize } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class JwtTokenInterceptor implements HttpInterceptor {

  constructor(private jwtHelper: JwtHelperService,
              private tokenService: TokenService,
              private authHelper: AuthHelper,
              private router: Router) {}

  isRefreshingToken = false;

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let clone: HttpRequest<any>;

    if ( this.authHelper.isAuthenticated() ) {

      let token = localStorage.getItem('token');
      const currentUser = this.authHelper.getCurrentUser();
      const refreshToken =  this.authHelper.getRefreshToken();

      console.log('Adding token header| isRefreshingToken: ', this.isRefreshingToken);

      if (this.jwtHelper.isTokenExpired(token) && !this.isRefreshingToken) {
        // Refresh token
        this.isRefreshingToken = true;

        return this.tokenService.refreshToken(currentUser.role, {uId: +currentUser.id, refreshToken: refreshToken})
          .pipe(switchMap((res) => {
            this.authHelper.setToken(res);
            token = localStorage.getItem('token');

            console.log('RefreshToken changed| isRefreshingToken:', this.isRefreshingToken);

            clone = this.cloneRequest(request, token);

            return next.handle(clone);
          }),

          catchError(() => {
            // If there is an exception calling 'refreshToken', bad news so logout.
            return this.logoutUser();
          }),

          finalize(() => {
            this.isRefreshingToken = false;

            console.log('RefreshToken finalized| isRefreshingToken:', this.isRefreshingToken);

          })

        );
      }

    clone = this.cloneRequest(request, token);

    } else {

      console.log('Unathorized . isRefreshingToken: ', this.isRefreshingToken);

      clone = this.cloneRequest(request, undefined);

    }

    return next.handle(clone);

  }

  logoutUser() {

    this.authHelper.logout();
    this.router.navigate(['/']);
    return observableThrowError('');

  }

  private cloneRequest(request, token: string): HttpRequest<any> {

    if (token) {

      return request.clone({
        setHeaders: {
          Accept: `application/json`,
          'Content-Type': `application/json`,
          Authorization: `Bearer ${token}`
        }
      });

    } else {

      return request.clone({
        setHeaders: {
          Accept: `application/json`,
          'Content-Type': `application/json`
        }
      });

    }
  }

}
