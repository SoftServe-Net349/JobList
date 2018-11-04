import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { LoginRequest } from '../../shared/models/login-request.model';
import { Token } from '../../shared/models/token.model';
import { RefreshTokenRequest } from '../../shared/models/refresh-token-request.model';

@Injectable()
export class TokenService {

  private ctrlUrl = 'tokens';

  constructor(private apiService: ApiService) {
  }

  getTokenForFacebookAuth(role: string, accessToken: string) {
    return this.apiService.post(`/${ role + this.ctrlUrl}/facebook`, JSON.stringify({ accessToken }));
  }

  getToken(role: string, request: LoginRequest): Observable<Token> {
    return this.apiService.post(`/${role + this.ctrlUrl}/token`, request);
  }

  refreshToken(role: string, request: RefreshTokenRequest): Observable<Token> {
    if (role === 'admin') { role = 'employee'; }
    return this.apiService.post(`/${role + this.ctrlUrl}/refresh`, request);
  }

}
