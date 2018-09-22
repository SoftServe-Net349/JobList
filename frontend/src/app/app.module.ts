import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

import {ButtonModule} from 'primeng/button';
import {DropdownModule} from 'primeng/dropdown';
import {RadioButtonModule} from 'primeng/radiobutton';
import {InputSwitchModule} from 'primeng/inputswitch';
import {SliderModule} from 'primeng/slider';

import { JobSearchComponent } from './job-search/job-search.component';
import { ResumeComponent } from './resume/resume.component';
import { RecomendedComponent } from './recomended/recomended.component';
import { AuthorizationsComponent } from './authorizations/authorizations.component';
import { ProfileComponent } from './profile/profile.component';
import { JobFiltersComponent } from './job-filters/job-filters.component';
import { CompanyFiltersComponent } from './company-filters/company-filters.component';

@NgModule({
  declarations: [
    AppComponent,
    JobSearchComponent,
    ResumeComponent,
    RecomendedComponent,
    AuthorizationsComponent,
    ProfileComponent,
    JobFiltersComponent,
    CompanyFiltersComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ButtonModule,
    DropdownModule,
    RadioButtonModule,
    InputSwitchModule,
    SliderModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
