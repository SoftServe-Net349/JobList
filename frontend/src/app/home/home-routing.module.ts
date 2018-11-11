import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobSearchComponent } from '../job-search/job-search.component';
import { ResumesSearchComponent } from '../resumes-search/resumes-search.component';
import { CompanyDetailsComponent } from '../company-details/company-details.component';
import { ResumeDetailsComponent } from '../resume-details/resume-details.component';
import { VacancyDetailsComponent } from '../vacancy-details/vacancy-details.component';

import { HomeComponent } from './home.component';
import { MainSearchComponent } from './main-search/main-search.component';
import { AuthGuard } from '../core/guards/auth.guard';
import { CompanyRecruiterAdminGuard } from '../core/guards/company-recruiter-admin.guard';
import { AdminAuthorizationComponent } from '../admin-authorization/admin-authorization.component';
import { ChatComponent } from '../chat/chat.component';

const childRoutes: Routes = [
  { path: '', component: MainSearchComponent, pathMatch: 'full' },
  { path: 'jobsearch', component: JobSearchComponent },
  { path: 'resumessearch', component: ResumesSearchComponent, canActivate: [AuthGuard, CompanyRecruiterAdminGuard] },
  { path: 'company-details/:id', component: CompanyDetailsComponent },
  { path: 'resume-details/:id', component: ResumeDetailsComponent, canActivate: [AuthGuard, CompanyRecruiterAdminGuard] },
  { path: 'vacancy-details/:id', component: VacancyDetailsComponent },
  { path: 'admin', component: AdminAuthorizationComponent },
  { path: 'chat', component: ChatComponent}
];

const routes: Routes = [
  { path: '', component: HomeComponent, children: childRoutes }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
