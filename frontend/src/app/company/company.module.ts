import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyRoutingModule } from './company-routing.module';
import { CompanyComponent } from './company.component';
import { HeaderComponent } from '../shared/header/header.component';
import { FooterComponent } from '../shared/footer/footer.component';
import { CompanyHeaderComponent } from './company-header/company-header.component';
import { RecruiterFormComponent } from '../recruiter-form/recruiter-form.component';
import { CompanyInfoFormComponent } from '../company-info-form/company-info-form.component';

import { MessageService } from 'primeng/api';

import {ButtonModule} from 'primeng/button';
import {AccordionModule} from 'primeng/accordion';
import {DialogModule} from 'primeng/dialog';
import {InputTextModule} from 'primeng/inputtext';
import {FileUploadModule} from 'primeng/fileupload';
import {SidebarModule} from 'primeng/sidebar';
import {PanelMenuModule} from 'primeng/panelmenu';

@NgModule({
  imports: [
    CommonModule,
    CompanyRoutingModule,
    ButtonModule,
    AccordionModule,
    DialogModule,
    InputTextModule,
    FileUploadModule,
    SidebarModule,
    PanelMenuModule
  ],
  declarations: [
    CompanyComponent,
    HeaderComponent,
    FooterComponent,
    RecruiterFormComponent,
    CompanyHeaderComponent,
    CompanyInfoFormComponent
  ],
  providers: [MessageService]
})
export class CompanyModule { }
