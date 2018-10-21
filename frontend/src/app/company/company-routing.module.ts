import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CompanyComponent } from './company.component';
import { AuthGuard } from '../core/guards/auth.guard';
import { CompanyGuard } from '../core/guards/company.guard';

const routes: Routes = [
  { path: '', component: CompanyComponent, canActivate: [AuthGuard, CompanyGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
