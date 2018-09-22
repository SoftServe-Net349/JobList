import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SomePipe } from './pipes/some.pipe';
import { SomeDirective } from './directives/some.directive';
import { HeaderComponent } from './header/header.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [SomePipe, SomeDirective, HeaderComponent],
  exports: [
    CommonModule,
    SomePipe,
    SomeDirective
  ]
})
export class SharedModule { }
