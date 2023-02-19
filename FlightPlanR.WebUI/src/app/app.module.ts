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
import { PrimeNgComponentsModule } from "./common/prime-ng/prime-ng.module";
import { FormsModule } from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {LocalStorageService} from "./common/localStorage.service";
import {AccountService} from "./services/account.service";
import {FlightPlanService} from "./services/flight-plan.service";

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    HomeComponent,
    FlightPlansComponent,
    AdministrationComponent,
    LoginComponent
  ],
  imports: [
    AppRoutingModule,
    PrimeNgComponentsModule,
    FormsModule,
    HttpClientModule
  ],
  exports: [
    AppRoutingModule,
    PrimeNgComponentsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
