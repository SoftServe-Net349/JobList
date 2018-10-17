import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RecruiterComponent } from './recruiter.component';
import { AuthGuard } from '../core/guards/auth.guard';
import { RecruiterGuard } from '../core/guards/recruiter.guard';

const routes: Routes = [
  { path: 'recruiters/:id', component: RecruiterComponent, canActivate: [AuthGuard, RecruiterGuard] }
];



@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecruiterRoutingModule { }
