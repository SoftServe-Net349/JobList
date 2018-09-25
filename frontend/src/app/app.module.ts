import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

// PrimeNG modules
import {ButtonModule} from 'primeng/button';
import {DropdownModule} from 'primeng/dropdown';
import {RadioButtonModule} from 'primeng/radiobutton';
import {InputSwitchModule} from 'primeng/inputswitch';
import {SliderModule} from 'primeng/slider';
import {MultiSelectModule} from 'primeng/multiselect';

// Our created components
import { JobSearchComponent } from './job-search/job-search.component';
import { ResumeComponent } from './resume/resume.component';
import { RecomendedComponent } from './recomended/recomended.component';
import { AuthorizationsComponent } from './authorizations/authorizations.component';
import { ProfileComponent } from './profile/profile.component';
import { JobFiltersComponent } from './job-filters/job-filters.component';
import { CompanyFiltersComponent } from './company-filters/company-filters.component';

// Our created modules
import { HomeModule } from './home/home.module';
import { UserModule } from './user/user.module';
import { AdminModule } from './admin/admin.module';
import { RecruiterModule } from './recruiter/recruiter.module';
import { CompanyModule } from './company/company.module';


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
    SliderModule,
    MultiSelectModule,
    HomeModule,
    UserModule,
    AdminModule,
    RecruiterModule,
    CompanyModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
