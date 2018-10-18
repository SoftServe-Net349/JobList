import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SomePipe } from './pipes/some.pipe';
import { SomeDirective } from './directives/some.directive';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// PrimeNG modules
import { DialogModule } from 'primeng/dialog';
import {CheckboxModule} from 'primeng/checkbox';
import {InputTextModule} from 'primeng/inputtext';
import {PasswordModule} from 'primeng/password';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import {SidebarModule} from 'primeng/sidebar';
import {PanelMenuModule} from 'primeng/panelmenu';
import {RadioButtonModule} from 'primeng/radiobutton';
import {MenuModule} from 'primeng/menu';
import {CalendarModule} from 'primeng/calendar';

// Our created components
import { AuthorizationsComponent } from '../authorizations/authorizations.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { SearchLineComponent } from './search-line/search-line.component';

// Our created modules

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ButtonModule,
    DropdownModule,
    DialogModule,
    CheckboxModule,
    InputTextModule,
    PasswordModule,
    SidebarModule,
    PanelMenuModule,
    RadioButtonModule,
    ReactiveFormsModule,
    MenuModule,
    CalendarModule
  ],
  declarations: [
    SomePipe,
    SomeDirective,
    HeaderComponent,
    FooterComponent,
    SearchLineComponent,
    AuthorizationsComponent
  ],
  providers: [],
  exports: [
    CommonModule,
    SomePipe,
    SomeDirective,
    FooterComponent,
    HeaderComponent,
    SearchLineComponent,
    AuthorizationsComponent
  ]
})
export class SharedModule { }
