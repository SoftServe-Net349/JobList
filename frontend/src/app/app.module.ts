import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

// PrimeNG modules

// Our created components

// Our created modules
import { HomeModule } from './home/home.module';
import { EmployeeModule } from './employee/employee.module';
import { AdminModule } from './admin/admin.module';
import { RecruiterModule } from './recruiter/recruiter.module';
import { CompanyModule } from './company/company.module';
import { CoreModule } from './core/core.module';

import { JwtModule } from '@auth0/angular-jwt';

import { AuthHelper } from './shared/helpers/auth-helper';

export function tokenGetter() {

  return  window.localStorage.getItem('token');

}

@NgModule({
  declarations: [
  AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HomeModule,
    EmployeeModule,
    AdminModule,
    RecruiterModule,
    CompanyModule,
    CoreModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter
      }
    })
  ],
  providers: [
    AuthHelper
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
