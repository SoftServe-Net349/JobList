import { NgModule, Optional, SkipSelf } from '@angular/core';
import { throwIfAlreadyLoaded } from './guards/module-import.guard';
import { CommonModule } from '@angular/common';
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
import { UserService } from './services/user.service';
import { AuthGuard } from './guards/auth.guard';
import { AuthService } from './services/auth.service';
import { TokenService } from './services/token.service';
import { AdminGuard } from './guards/admin.guard';
import { UserGuard } from './guards/user.guard';
import { CompanyGuard } from './guards/company.guard';
import { RecruiterGuard } from './guards/recruiter.guard';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    ApiService,
    CompanyService,
    CityService,
    WorkAreaService,
    SchoolService,
    FacultyService,
    LanguageService,
    RecruiterService,
    ResumeService,
    VacancyService,
    UserService,
    AuthGuard,
    AuthService,
    TokenService,
    AdminGuard,
    UserGuard,
    CompanyGuard,
    RecruiterGuard
  ],
  declarations: []
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}
