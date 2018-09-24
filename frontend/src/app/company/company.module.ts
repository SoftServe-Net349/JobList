import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyRoutingModule } from './company-routing.module';
import { CompanyComponent } from './company.component';
import { HeaderComponent } from '../shared/header/header.component';
import { FooterComponent } from '../shared/footer/footer.component';

import {ButtonModule} from 'primeng/button';
import {AccordionModule} from 'primeng/accordion';

@NgModule({
  imports: [
    CommonModule,
    CompanyRoutingModule,
    ButtonModule,
    AccordionModule
  ],
  declarations: [
    CompanyComponent,
    HeaderComponent,
    FooterComponent
  ]
})
export class CompanyModule { }
