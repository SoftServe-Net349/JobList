import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../models/user.model';

@Injectable()

export class AuthHelper  {

    private authenticationChanged = new Subject<boolean>();

    currentUser: User;

    constructor(private jwtHelper: JwtHelperService) {
    }

    public isAuthenticated(): boolean {

        const token = window.localStorage['token'];

        return (!(token === undefined ||

            token === null ||

            token === 'null' ||

            token === 'undefined' ||

            token === ''));

    }

    public isAuthenticationChanged(): any {

        return this.authenticationChanged.asObservable();

    }

    public getToken(): any {

        const token = window.localStorage['token'];

        if ( token === undefined ||

            token === null ||

            token === 'null' ||

            token === 'undefined' ||

            token === '') {

            return '';

        }

        const obj = token;

        return obj;

    }

    public getRefreshToken(): any {

        const refreshToken = window.localStorage['refreshToken'];

        if ( refreshToken === undefined ||

            refreshToken === null ||

            refreshToken === 'null' ||

            refreshToken === 'undefined' ||

            refreshToken === '') {

            return '';

        }

        const obj = refreshToken;

        return obj;

    }

    public getCurrentUser(): User {

        const currentUser = window.localStorage['currentUser'];

        if ( currentUser === undefined ||

            currentUser === null ||

            currentUser === 'null' ||

            currentUser === 'undefined' ||

            currentUser === '') {

        return null;

        }

        const obj = JSON.parse(currentUser);

        return obj;

    }

    public setToken(data: any): void {

        const decodeToken = this.jwtHelper.decodeToken(data.jwt);
        const currentUser: User = {
            id: decodeToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
            role: decodeToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
        };

        this.setStorageToken(data.jwt);
        this.setStorageRefreshToken(data.refreshToken);
        this.setCurrentUser(JSON.stringify(currentUser));

    }

    public failToken(): void {

        this.setCurrentUser(undefined);
        this.setStorageToken(undefined);
        this.setStorageRefreshToken(undefined);

    }

    public logout(): void {

        this.setCurrentUser(undefined);
        this.setStorageToken(undefined);
        this.setStorageRefreshToken(undefined);

    }

    private setStorageToken(value: any): void {

        window.localStorage['token'] = value;

        this.authenticationChanged.next(this.isAuthenticated());
    }

    private setStorageRefreshToken(value: any): void {

        window.localStorage['refreshToken'] = value;

    }

    private setCurrentUser(value: any) {

        window.localStorage['currentUser'] = value;

    }

}
