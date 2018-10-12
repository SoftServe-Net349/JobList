import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { AdminCompaniesComponent } from './admin-companies/admin-companies.component';

const childRoutes: Routes = [
  { path: 'admin-users', component: AdminUsersComponent },
  { path: 'admin-companies', component: AdminCompaniesComponent }
];

const routes: Routes = [
  { path: 'admin', component: AdminComponent, children: childRoutes }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
