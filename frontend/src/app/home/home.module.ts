import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { MainSearchComponent } from './main-search/main-search.component';
import { JobSearchComponent } from '../job-search/job-search.component';
import { JobFiltersComponent } from '../job-filters/job-filters.component';
import { CompanyFiltersComponent } from '../company-filters/company-filters.component'
import { ResumesSearchComponent } from '../resumes-search/resumes-search.component'

import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputSwitchModule } from 'primeng/inputswitch';
import { SliderModule } from 'primeng/slider';
import { MultiSelectModule } from 'primeng/multiselect';
import { SharedModule } from '../shared/shared.module';

import {DropdownModule} from 'primeng/dropdown';
import {ButtonModule} from 'primeng/button';

@NgModule({
  imports: [
    ButtonModule,
    CommonModule,
    HomeRoutingModule,
    FormsModule,
    ButtonModule,
    DropdownModule,
    RadioButtonModule,
    InputSwitchModule,
    SliderModule,
    MultiSelectModule,
    SharedModule
  ],
  declarations: [
    HomeComponent,
    MainSearchComponent,
    JobSearchComponent,
    JobFiltersComponent,
    CompanyFiltersComponent,
    ResumesSearchComponent
  ]
})
export class HomeModule { }
