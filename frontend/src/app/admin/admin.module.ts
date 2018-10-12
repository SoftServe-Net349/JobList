import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { DataViewModule } from 'primeng/dataview';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { PanelModule, DialogModule, ButtonModule, DropdownModule, SidebarModule, PanelMenuModule, PaginatorModule } from 'primeng/primeng';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { AdminHeaderComponent } from './admin-header/admin-header.component';
import { AdminCompaniesComponent } from './admin-companies/admin-companies.component';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import {InputTextModule} from 'primeng/inputtext';



@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,
    DataViewModule,
    PanelModule,
    DialogModule,
    ButtonModule,
    DropdownModule,
    FormsModule,
    SidebarModule,
    PanelMenuModule,
    PaginatorModule,
    SharedModule,
    ConfirmDialogModule,
    InputTextModule
  ],
  declarations: [AdminComponent, AdminCompaniesComponent, AdminUsersComponent, AdminHeaderComponent]
})
export class AdminModule { }
