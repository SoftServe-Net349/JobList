import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

// PrimeNG modules

// Our created components

// Our created modules
import { JwtModule } from '@auth0/angular-jwt';

import { AuthHelper } from './shared/helpers/auth-helper';
import { JwtTokenInterceptor } from './core/interceptors/jwt-token-interceptor';
import { TokenService } from './core/services/token.service';
import { ApiService } from './core/services/api.service';

export function tokenGetter() {

  return  window.localStorage.getItem('token');

}

@NgModule({
  declarations: [
  AppComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter
      }
    })
  ],
  providers: [
    AuthHelper,
    TokenService,
    ApiService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtTokenInterceptor, multi: true }
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
