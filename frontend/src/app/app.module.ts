import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

// PrimeNG modules
import { FieldsetModule } from 'primeng/fieldset';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';

// Our created components

// Our created modules
import { HomeModule } from './home/home.module';
import { UserModule } from './user/user.module';
import { AdminModule } from './admin/admin.module';
import { RecruiterModule } from './recruiter/recruiter.module';
import { CompanyModule } from './company/company.module';
import { CoreModule } from './core/core.module';
import { ResumeDetailsComponent } from './resume-details/resume-details.component';



@NgModule({
  declarations: [
  AppComponent,
  ResumeDetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HomeModule,
    UserModule,
    AdminModule,
    RecruiterModule,
    CompanyModule,
    CoreModule,
    FieldsetModule,
    DialogModule,
    ButtonModule
  ],
  providers: [],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
