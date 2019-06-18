import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminCompaniesComponent } from './admin-companies/admin-companies.component';
import { AdminVacanciesComponent } from './admin-vacancies/admin-vacancies.component';
import { AdminRecruitersComponent } from './admin-recruiters/admin-recruiters.component';
import { AdminEmployeesComponent } from './admin-employees/admin-employees.component';
import { AuthGuard } from '../core/guards/auth.guard';
import { AdminGuard } from '../core/guards/admin.guard';
import { AdminChatComponent } from './admin-chat/admin-chat.component';

const childRoutes: Routes = [
  { path: 'admin-employees', component: AdminEmployeesComponent, canActivate: [AuthGuard, AdminGuard] },
  { path: 'admin-companies', component: AdminCompaniesComponent, canActivate: [AuthGuard, AdminGuard] },
  { path: 'admin-vacancies', component: AdminVacanciesComponent, canActivate: [AuthGuard, AdminGuard] },
  { path: 'admin-recruiters', component: AdminRecruitersComponent, canActivate: [AuthGuard, AdminGuard] },
  { path: 'admin-chat', component: AdminChatComponent, canActivate: [AuthGuard, AdminGuard]}
];

const routes: Routes = [
  { path: '', component: AdminComponent, children: childRoutes }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
