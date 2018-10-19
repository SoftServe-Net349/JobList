import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { TokenService } from '../services/token.service';
import { AuthHelper } from '../../shared/helpers/auth-helper';
import { switchMap } from 'rxjs/operators';
import { Token } from '../../shared/models/token.model';

@Injectable()
export class JwtTokenInterceptor implements HttpInterceptor {
  constructor(private jwtHelper: JwtHelperService,
              private tokenService: TokenService,
              private authHelper: AuthHelper) {

  }

  isRefreshingToken = false;

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      let clone: HttpRequest<any>;

      if ( this.authHelper.isAuthenticated() ) {

        let token = localStorage.getItem('token');
        const currentUser = this.authHelper.getCurrentUser();
        const refreshToken =  this.authHelper.getRefreshToken();

        if (this.jwtHelper.isTokenExpired(token) && !this.isRefreshingToken) {
          // renew token
          this.isRefreshingToken = true;

          return this.tokenService.refreshToken(currentUser.role, {uId: +currentUser.id, refreshToken: refreshToken})
            .pipe(switchMap((res) => {
              this.authHelper.setToken(res);
              token = localStorage.getItem('token');

              clone = request.clone({
                setHeaders: {
                  Accept: `application/json`,
                  'Content-Type': `application/json`,
                  Authorization: `Bearer ${token}`
                }
              });

              return next.handle(clone);
            })
          );
        }

      clone = request.clone({
        setHeaders: {
          Accept: `application/json`,
          'Content-Type': `application/json`,
          Authorization: `Bearer ${token}`
        }
      });

      } else {
        clone = request.clone({
          setHeaders: {
            Accept: `application/json`,
            'Content-Type': `application/json`
          }
        });
      }
      return next.handle(clone);
  }
}
