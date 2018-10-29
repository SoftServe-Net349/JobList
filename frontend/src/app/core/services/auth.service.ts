import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenService } from './token.service';
import { LoginRequest } from '../../shared/models/login-request.model';
import { Token } from '../../shared/models/token.model';
import { Employee } from '../../shared/models/employee.model';
import { EmployeeService } from './employee.service';
import { EmployeeRequest } from '../../shared/models/employee-request.model';
import { RecruiterService } from './recruiter.service';
import { CompanyService } from './company.service';
import { CompanyRequest } from '../../shared/models/company-request.model';
import { Company } from '../../shared/models/company.model';
import { Recruiter } from '../../shared/models/recruiter.model';
import { RecruiterRequest } from '../../shared/models/recruiter-request.model';

@Injectable()
export class AuthService {

  constructor(private tokenService: TokenService,
              private employeeServise: EmployeeService,
              private recruiterService: RecruiterService,
              private companyService: CompanyService) {}

  employeeLogin(request: LoginRequest): Observable<Token> {
    return this.tokenService.getToken('employee', request);
  }

  companyLogin(request: LoginRequest): Observable<Token> {
    return this.tokenService.getToken('company', request);
  }

  recruiterLogin(request: LoginRequest): Observable<Token> {
    return this.tokenService.getToken('recruiter', request);
  }

  employeeSignUp(request: EmployeeRequest): Observable<Employee> {
    return this.employeeServise.register(request);
  }

  companySignUp(request: CompanyRequest): Observable<Company> {
    return this.companyService.register(request);
  }

  recruiterSignUp(request: RecruiterRequest): Observable<Recruiter> {
    return this.recruiterService.register(request);
  }

}
