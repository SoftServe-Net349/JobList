import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { DataViewModule } from 'primeng/dataview';
import { PanelModule, DialogModule, ButtonModule, DropdownModule, SidebarModule, PanelMenuModule, PaginatorModule } from 'primeng/primeng';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { AdminHeaderComponent } from './admin-header/admin-header.component';
import { AdminCompaniesComponent } from './admin-companies/admin-companies.component';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { InputTextModule } from 'primeng/inputtext';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { AdminVacanciesComponent } from './admin-vacancies/admin-vacancies.component';
import { AdminRecruitersComponent } from './admin-recruiters/admin-recruiters.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { ChartModule } from 'primeng/chart';
import { AdminEmployeesComponent } from './admin-employees/admin-employees.component';

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
    InputTextModule,
    AutoCompleteModule,
    ChartModule
  ],
  declarations: [
    AdminComponent,
    AdminCompaniesComponent,
    AdminRecruitersComponent,
    AdminEmployeesComponent,
    AdminVacanciesComponent,
    AdminDashboardComponent,
    AdminHeaderComponent]
})
export class AdminModule { }
