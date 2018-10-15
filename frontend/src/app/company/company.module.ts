import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CompanyRoutingModule } from './company-routing.module';
import { CompanyComponent } from './company.component';
import { CompanyHeaderComponent } from './company-header/company-header.component';
import { RecruiterFormComponent } from '../recruiter-form/recruiter-form.component';
import { CompanyInfoFormComponent } from '../company-info-form/company-info-form.component';

import { MessageService } from 'primeng/api';
import {ConfirmationService} from 'primeng/api';

import { SharedModule } from '../shared/shared.module';

import {ButtonModule} from 'primeng/button';
import {AccordionModule} from 'primeng/accordion';
import {DialogModule} from 'primeng/dialog';
import {InputTextModule} from 'primeng/inputtext';
import {FileUploadModule} from 'primeng/fileupload';
import {SidebarModule} from 'primeng/sidebar';
import {PanelMenuModule} from 'primeng/panelmenu';
import {PasswordModule} from 'primeng/password';
import {InputMaskModule} from 'primeng/inputmask';
import {ConfirmDialogModule} from 'primeng/confirmdialog';

import { CoreModule } from '../core/core.module';
import { PaginatorModule } from 'primeng/paginator';

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
    SharedModule,
    PasswordModule,
    ReactiveFormsModule,
    InputMaskModule,
    ConfirmDialogModule,
    CoreModule,
    PaginatorModule
  ],
  declarations: [
    CompanyComponent,
    RecruiterFormComponent,
    CompanyHeaderComponent,
    CompanyInfoFormComponent
  ],
  providers: [MessageService, ConfirmationService]
})
export class CompanyModule { }
