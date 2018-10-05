import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


import { UserRoutingModule } from './user-routing.module';
import { UserComponent } from './user.component';
import { ButtonModule } from 'primeng/button';
import { AccordionModule } from 'primeng/accordion';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { SidebarModule } from 'primeng/sidebar';
import { FileUploadModule } from 'primeng/fileupload';
import { PanelMenuModule } from 'primeng/panelmenu';
import {CalendarModule} from 'primeng/calendar';
import {DropdownModule} from 'primeng/dropdown';
import {FieldsetModule} from 'primeng/fieldset';
import {PanelModule} from 'primeng/panel';
import {PasswordModule} from 'primeng/password';
import {InputMaskModule} from 'primeng/inputmask';
import {MultiSelectModule} from 'primeng/multiselect';

import { UserHeaderComponent } from './user-header/user-header.component';

import { ResumeFormComponent } from '../resume-form/resume-form.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    UserRoutingModule,
    ButtonModule,
    AccordionModule,
    DialogModule,
    InputTextModule,
    FileUploadModule,
    SidebarModule,
    PanelMenuModule,
    CalendarModule,
    DropdownModule,
    FormsModule,
    FieldsetModule,
    PanelModule,
    SharedModule,
    PasswordModule,
    InputMaskModule,
    ReactiveFormsModule,
    MultiSelectModule
  ],
  declarations: [
    UserComponent,
    ResumeFormComponent,
    UserHeaderComponent
  ]
})
export class UserModule { }
