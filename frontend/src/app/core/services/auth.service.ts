import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenService } from './token.service';
import { UserLoginRequest } from '../../shared/models/user-login-request.model';
import { Token } from '../../shared/models/token.model';

@Injectable()
export class AuthService {
  constructor(private tokenService: TokenService) {
  }

  login(request: UserLoginRequest): Observable<Token> {
    return this.tokenService.getToken(request);
  }

}
