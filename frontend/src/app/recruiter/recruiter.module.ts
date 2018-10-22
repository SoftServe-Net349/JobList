import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { RecruiterRoutingModule } from './recruiter-routing.module';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

import { RecruiterComponent } from './recruiter.component';

import { ButtonModule } from 'primeng/button';
import { AccordionModule } from 'primeng/accordion';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { FileUploadModule } from 'primeng/fileupload';
import { SidebarModule } from 'primeng/sidebar';
import { PanelMenuModule } from 'primeng/panelmenu';
import { VacancyFormComponent } from '../vacancy-form/vacancy-form.component';
import { DropdownModule } from 'primeng/dropdown';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import {KeyFilterModule} from 'primeng/keyfilter';

import { CoreModule } from '../core/core.module';
import { ConfirmationService, MessageService } from 'primeng/api';
import { PaginatorModule } from 'primeng/primeng';

@NgModule({
  imports: [
    CommonModule,
    RecruiterRoutingModule,
    ButtonModule,
    AccordionModule,
    DialogModule,
    InputTextModule,
    FileUploadModule,
    SidebarModule,
    PanelMenuModule,
    FormsModule,
    SharedModule,
    DropdownModule,
    ReactiveFormsModule,
    ConfirmDialogModule,
    KeyFilterModule,
    CoreModule,
    PaginatorModule 
  ],
  declarations: [
    RecruiterComponent,
    VacancyFormComponent
  ],
  providers: [MessageService, ConfirmationService]
})
export class RecruiterModule { }
