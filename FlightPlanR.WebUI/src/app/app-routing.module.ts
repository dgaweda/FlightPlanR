import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./pages/home/home.component";
import {FlightPlansComponent} from "./pages/flight-plans/flight-plans.component";
import {AdministrationComponent} from "./pages/administration/administration.component";

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    title: 'Home'
  },
  {
    path: 'flight-plans',
    component: FlightPlansComponent,
    title: 'Flight Plans'
  },
  {
    path: 'administration',
    component: AdministrationComponent,
    title: 'Administration'
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
