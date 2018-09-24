import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobSearchComponent } from '../job-search/job-search.component';
import { HomeComponent } from './home.component';
import { MainSearchComponent } from './main-search/main-search.component';

const childRoutes: Routes = [
  { path: 'jobsearch', component: JobSearchComponent}
];

const routes: Routes = [
  {path: '', component: HomeComponent, children: childRoutes}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
