import { Injectable } from '@angular/core';

import { Observable, Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Person } from '../models/person.model';

@Injectable()

export class AuthHelper  {

    private authenticationChanged = new Subject<boolean>();

    currentPerson: Person;

    constructor(private jwtHelper: JwtHelperService) {
    }

    public isAuthenticated(): boolean {

        return (!(window.localStorage['token'] === undefined ||

            window.localStorage['token'] === null ||

            window.localStorage['token'] === 'null' ||

            window.localStorage['token'] === 'undefined' ||

            window.localStorage['token'] === ''));

    }

    public isAuthenticationChanged(): any {

        return this.authenticationChanged.asObservable();

    }

    public getToken(): any {

        if ( window.localStorage['token'] === undefined ||

            window.localStorage['token'] === null ||

            window.localStorage['token'] === 'null' ||

            window.localStorage['token'] === 'undefined' ||

            window.localStorage['token'] === '') {

            return '';

        }

        const obj = window.localStorage['token'];

        return obj;

    }

    public getRefreshToken(): any {

        if ( window.localStorage['token'] === undefined ||

            window.localStorage['token'] === null ||

            window.localStorage['token'] === 'null' ||

            window.localStorage['token'] === 'undefined' ||

            window.localStorage['token'] === '') {

            return '';

        }

        const obj = window.localStorage['refreshToken'];

        return obj;

    }

    public getCurrentPerson(): Person {

        if ( window.localStorage['currentPerson'] === undefined ||

        window.localStorage['currentPerson'] === null ||

        window.localStorage['currentPerson'] === 'null' ||

        window.localStorage['currentPerson'] === 'undefined' ||

        window.localStorage['currentPerson'] === '') {

        return null;

        }

        const obj = JSON.parse(window.localStorage['currentPerson']);

        return obj;

    }

    public setToken(data: any): void {

        const decodeToken = this.jwtHelper.decodeToken(data.jwt);
        const currentPerson: Person = {
            id: decodeToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
            role: decodeToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
        };

        this.setStorageToken(data.jwt);
        this.setStorageRefreshToken(data.refreshToken);
        this.setCurrentPerson(JSON.stringify(currentPerson));

    }

    public failToken(): void {

        this.setCurrentPerson(undefined);
        this.setStorageToken(undefined);
        this.setStorageRefreshToken(undefined);

    }

    public logout(): void {

        this.setCurrentPerson(undefined);
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

    private setCurrentPerson(value: any) {

        window.localStorage['currentPerson'] = value;

    }

}
