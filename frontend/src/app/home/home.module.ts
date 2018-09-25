import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { MainSearchComponent } from './main-search/main-search.component';
import { JobSearchComponent } from '../job-search/job-search.component';

@NgModule({
  imports: [
    CommonModule,
    HomeRoutingModule
  ],
  declarations: [
    HomeComponent,
    MainSearchComponent,
    JobSearchComponent]
})
export class HomeModule { }
