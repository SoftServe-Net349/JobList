import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { MainSearchComponent } from './main-search/main-search.component';

import { HeaderComponent } from '../shared/header/header.component';
import { FooterComponent } from '../shared/footer/footer.component';
import { SearchLineComponent } from '../shared/search-line/search-line.component';

import {ButtonModule} from 'primeng/button';
import {DropdownModule} from 'primeng/dropdown';
import { JobSearchComponent } from '../job-search/job-search.component';
import { JobFiltersComponent } from '../job-filters/job-filters.component';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputSwitchModule } from 'primeng/inputswitch';
import { SliderModule } from 'primeng/slider';
import { MultiSelectModule } from 'primeng/multiselect';


@NgModule({
  imports: [
    CommonModule,
    HomeRoutingModule,
    FormsModule,
    ButtonModule,
    DropdownModule,
    RadioButtonModule,
    InputSwitchModule,
    SliderModule,
    MultiSelectModule
  ],
  declarations: [
    HomeComponent,
    MainSearchComponent,
    HeaderComponent,
    FooterComponent,
    SearchLineComponent,
    JobSearchComponent,
    JobFiltersComponent
  ]
})
export class HomeModule { }
