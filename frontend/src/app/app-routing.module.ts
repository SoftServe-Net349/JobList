import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobFiltersComponent } from './job-filters/job-filters.component';
import { CompanyFiltersComponent } from './company-filters/company-filters.component';
import { HomeComponent } from './home/home.component';
import { CompanyComponent } from './company/company.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
