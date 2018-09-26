import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SomePipe } from './pipes/some.pipe';
import { SomeDirective } from './directives/some.directive';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { SearchLineComponent } from './search-line/search-line.component';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ButtonModule,
    DropdownModule
  ],
  declarations: [SomePipe, SomeDirective, HeaderComponent, FooterComponent, SearchLineComponent],
  exports: [
    CommonModule,
    SomePipe,
    SomeDirective,
    FooterComponent,
    HeaderComponent,
    SearchLineComponent
  ]
})
export class SharedModule { }
