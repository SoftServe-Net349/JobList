import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { MainSearchComponent } from './main-search/main-search.component';

import { HeaderComponent } from '../shared/header/header.component';
import { FooterComponent } from '../shared/footer/footer.component';

import {DropdownModule} from 'primeng/dropdown';
import {ButtonModule} from 'primeng/button';

@NgModule({
  imports: [
    ButtonModule,
    CommonModule,
    HomeRoutingModule,
    DropdownModule,
    FormsModule
  ],
  declarations: [
    HomeComponent,
    MainSearchComponent,
    HeaderComponent,
    FooterComponent
  ]
})
export class HomeModule { }
