import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// Our components
import { CompanyComponent } from './company.component';
import { RecruiterFormComponent } from '../recruiter-form/recruiter-form.component';
import { CompanyInfoFormComponent } from '../company-info-form/company-info-form.component';

// Our modules
import { CoreModule } from '../core/core.module';
import { SharedModule } from '../shared/shared.module';
import { CompanyRoutingModule } from './company-routing.module';

// PrimeNG modules & services
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
import { PaginatorModule } from 'primeng/paginator';

import { MessageService } from 'primeng/api';
import {ConfirmationService} from 'primeng/api';

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
    CompanyInfoFormComponent
  ],
  providers: [MessageService, ConfirmationService]
})
export class CompanyModule { }
