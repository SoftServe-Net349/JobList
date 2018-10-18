import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeComponent } from './employee.component';
import { AuthGuard } from '../core/guards/auth.guard';
import { EmployeeGuard } from '../core/guards/employee.guard';

const routes: Routes = [
  { path: 'employees/:id', component: EmployeeComponent, canActivate: [AuthGuard, EmployeeGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class EmployeeRoutingModule { }
