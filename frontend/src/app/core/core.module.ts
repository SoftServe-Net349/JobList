import { NgModule, Optional, SkipSelf } from '@angular/core';
import { throwIfAlreadyLoaded } from './guards/module-import.guard';
import { CommonModule } from '@angular/common';

// Services
import { CompanyService } from './services/company.service';
import { CityService } from './services/city.service';
import { WorkAreaService } from './services/work-area.service';
import { FacultyService } from './services/faculty.service';
import { SchoolService } from './services/school.service';
import { LanguageService } from './services/language.service';
import { ApiService } from './services/api.service';
import { RecruiterService } from './services/recruiter.service';
import { ResumeService } from './services/resume.service';
import { VacancyService } from './services/vacancy.service';
import { EmployeeService } from './services/employee.service';
import { TokenService } from './services/token.service';
import { InvitationHubService } from './hubs/invitation.hub';
import { InvitationService } from './services/invitation.service';

// Guards
import { AuthGuard } from './guards/auth.guard';
import { AdminGuard } from './guards/admin.guard';
import { EmployeeGuard } from './guards/employee.guard';
import { CompanyGuard } from './guards/company.guard';
import { RecruiterGuard } from './guards/recruiter.guard';
import { CompanyRecruiterAdminGuard } from './guards/company-recruiter-admin.guard';
import { AuthService } from './services/auth.service';
import { AuthHelper } from '../shared/helpers/auth-helper';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    AuthService,
    CompanyService,
    CityService,
    WorkAreaService,
    SchoolService,
    FacultyService,
    LanguageService,
    RecruiterService,
    ResumeService,
    VacancyService,
    EmployeeService,
    AuthGuard,
    TokenService,
    AdminGuard,
    EmployeeGuard,
    CompanyGuard,
    RecruiterGuard,
    CompanyRecruiterAdminGuard,
    InvitationHubService,
    InvitationService
  ],
  declarations: []
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}
