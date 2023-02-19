import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./pages/home/home.component";
import {FlightPlansComponent} from "./pages/flight-plans/flight-plans.component";
import {AdministrationComponent} from "./pages/administration/administration.component";
import {LoginComponent} from "./pages/login/login.component";

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    title: 'FlightPlanR - Home'
  },
  {
    path: 'flight-plans',
    component: FlightPlansComponent,
    title: 'FlightPlanR - Flight Plans'
  },
  {
    path: 'administration',
    component: AdministrationComponent,
    title: 'FlightPlanR - Administration'
  },
  {
    path: 'login',
    component: LoginComponent,
    title: 'FlightPlanR - Login'
  },
  {
    path: '**',
    redirectTo: 'home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
