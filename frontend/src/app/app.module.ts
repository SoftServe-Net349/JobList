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
import { UserModule } from './user/user.module';
import { AdminModule } from './admin/admin.module';
import { RecruiterModule } from './recruiter/recruiter.module';
import { CompanyModule } from './company/company.module';
import { ButtonModule } from 'primeng/button';
import { AccordionModule } from 'primeng/accordion';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { FileUploadModule } from 'primeng/fileupload';
import { SidebarModule } from 'primeng/sidebar';
import { PanelMenuModule } from 'primeng/panelmenu';
import { VacancyFormComponent } from './vacancy-form/vacancy-form.component';
import { DropdownModule } from 'primeng/dropdown';

@NgModule({
  declarations: [
	AppComponent,
	VacancyFormComponent
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
	ButtonModule,
    AccordionModule,
    DialogModule,
    InputTextModule,
    FileUploadModule,
	SidebarModule,
	DropdownModule,
    PanelMenuModule
  ],
  providers: [],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
