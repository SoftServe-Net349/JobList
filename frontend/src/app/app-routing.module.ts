import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { JobFiltersComponent } from './job-filters/job-filters.component';
import { CompanyFiltersComponent } from './company-filters/company-filters.component';


const routes: Routes = [
  {path: 'job-filters', component: JobFiltersComponent},
  {path: 'company-filters', component: CompanyFiltersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
