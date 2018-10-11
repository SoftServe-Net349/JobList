import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { UserLoginRequest } from '../../shared/models/user-login-request.model';
import { Token } from '../../shared/models/token.model';
import { RefreshTokenRequest } from '../../shared/models/refresh-token-request.model';

@Injectable()
export class TokenService {
  private ctrlUrl = 'tokens';

  constructor(private apiService: ApiService) {
  }

  getToken(request: UserLoginRequest): Observable<Token> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  refreshToken(request: RefreshTokenRequest): Observable<Token> {
    return this.apiService.post(`/${this.ctrlUrl}/refresh`, request);
  }

}
