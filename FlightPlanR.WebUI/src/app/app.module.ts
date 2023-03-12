import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { FooterComponent } from './layout/footer/footer.component';
import { HomeComponent } from './pages/home/home.component';
import { FlightPlansComponent } from './pages/flight-plans/flight-plans.component';
import { AdministrationComponent } from './pages/administration/administration.component';
import { LoginComponent } from './pages/login/login.component';
import { PrimeNgComponentsModule } from "./common/prime-ng.module";
import { FormsModule } from "@angular/forms";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {StyleClassModule} from "primeng/styleclass";
import {JwtInterceptor} from "./common/interceptors/jwt.interceptor";
import {ErrorInterceptor} from "./common/interceptors/error.interceptor";
import {NotificationComponent} from "./components/notification/notification.component";
import {MessageService} from "primeng/api";

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    HomeComponent,
    FlightPlansComponent,
    AdministrationComponent,
    LoginComponent,
    NotificationComponent
  ],
  imports: [
    AppRoutingModule,
    PrimeNgComponentsModule,
    FormsModule,
    HttpClientModule,
    StyleClassModule
  ],
  exports: [
    AppRoutingModule,
    PrimeNgComponentsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    MessageService
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
