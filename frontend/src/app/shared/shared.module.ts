import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SomePipe } from './pipes/some.pipe';
import { SomeDirective } from './directives/some.directive';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [SomePipe, SomeDirective, HeaderComponent, FooterComponent],
  exports: [
    CommonModule,
    SomePipe,
    SomeDirective
  ]
})
export class SharedModule { }
