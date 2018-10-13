import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { MainSearchComponent } from './main-search/main-search.component';
import { JobSearchComponent } from '../job-search/job-search.component';
import { JobFiltersComponent } from '../job-filters/job-filters.component';
import { CompanyFiltersComponent } from '../company-filters/company-filters.component';
import { ResumesSearchComponent } from '../resumes-search/resumes-search.component';
import { CompanyDetailsComponent } from '../company-details/company-details.component';
import { ResumeDetailsComponent } from '../resume-details/resume-details.component';
import { VacancyDetailsComponent } from '../vacancy-details/vacancy-details.component';

import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputSwitchModule } from 'primeng/inputswitch';
import { SliderModule } from 'primeng/slider';
import { MultiSelectModule } from 'primeng/multiselect';
import { SharedModule } from '../shared/shared.module';
import { CardModule } from 'primeng/card';
import { DialogModule } from 'primeng/dialog';
import { FieldsetModule } from 'primeng/fieldset';
import {PaginatorModule} from 'primeng/paginator';
import {KeyFilterModule} from 'primeng/keyfilter';


import { CoreModule } from '../core/core.module';

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
    SharedModule,
    FieldsetModule,
    DialogModule,
    CardModule,
    PaginatorModule,
    CoreModule,
    KeyFilterModule
  ],
  declarations: [
    HomeComponent,
    MainSearchComponent,
    JobSearchComponent,
    JobFiltersComponent,
    CompanyFiltersComponent,
    ResumesSearchComponent,
    CompanyDetailsComponent,
    ResumeDetailsComponent,
    VacancyDetailsComponent
  ]
})
export class HomeModule { }
