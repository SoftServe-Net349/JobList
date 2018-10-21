import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: './home/home.module#HomeModule', pathMatch: 'prefix' },
  { path: 'companies/:id', loadChildren: './company/company.module#CompanyModule'},
  { path: 'employees/:id', loadChildren: './employee/employee.module#EmployeeModule'},
  { path: 'recruiters/:id', loadChildren: './recruiter/recruiter.module#RecruiterModule'}
 ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
