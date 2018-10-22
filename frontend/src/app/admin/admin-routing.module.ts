import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminCompaniesComponent } from './admin-companies/admin-companies.component';
import { AdminVacanciesComponent } from './admin-vacancies/admin-vacancies.component';
import { AdminRecruitersComponent } from './admin-recruiters/admin-recruiters.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminEmployeesComponent } from './admin-employees/admin-employees.component';

const childRoutes: Routes = [
  { path: 'admin-employees', component: AdminEmployeesComponent },
  { path: 'admin-companies', component: AdminCompaniesComponent },
  { path: 'admin-vacancies', component: AdminVacanciesComponent },
  { path: 'admin-recruiters', component: AdminRecruitersComponent },
  { path: 'admin-dashboard', component: AdminDashboardComponent }
];

const routes: Routes = [
  { path: '', component: AdminComponent, children: childRoutes }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
