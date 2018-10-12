import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenService } from './token.service';
import { LoginRequest } from '../../shared/models/login-request.model';
import { Token } from '../../shared/models/token.model';
import { User } from '../../shared/models/user.model';
import { UserService } from './user.service';
import { UserRequest } from '../../shared/models/user-request.model';
import { RecruiterService } from './recruiter.service';
import { CompanyService } from './company.service';
import { CompanyRequest } from '../../shared/models/company-request.model';
import { Company } from '../../shared/models/company.model';
import { Recruiter } from '../../shared/models/recruiter.model';
import { RecruiterRequest } from '../../shared/models/recruiter-request.model';

@Injectable()
export class AuthService {
  constructor(private tokenService: TokenService,
              private userServise: UserService,
              private recruiterService: RecruiterService,
              private companyService: CompanyService) {
  }

  userLogin(request: LoginRequest): Observable<Token> {
    return this.tokenService.getToken('user', request);
  }

  companyLogin(request: LoginRequest): Observable<Token> {
    return this.tokenService.getToken('company', request);
  }

  recruiterLogin(request: LoginRequest): Observable<Token> {
    return this.tokenService.getToken('recruiter', request);
  }

  userSignUp(request: UserRequest): Observable<User> {
    return this.userServise.register(request);
  }

  companySignUp(request: CompanyRequest): Observable<Company> {
    return this.companyService.register(request);
  }

  recruiterSignUp(request: RecruiterRequest): Observable<Recruiter> {
    return this.recruiterService.register(request);
  }

}
