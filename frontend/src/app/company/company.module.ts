import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { CompanyRoutingModule } from './company-routing.module';
import { CompanyComponent } from './company.component';
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
import { SharedModule } from '../shared/shared.module';

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
    PanelMenuModule,
    FormsModule,
    SharedModule
  ],
  declarations: [
    CompanyComponent,
    RecruiterFormComponent,
    CompanyHeaderComponent,
    CompanyInfoFormComponent
  ],
  providers: [MessageService]
})
export class CompanyModule { }
