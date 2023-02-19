import { Component, OnInit } from '@angular/core';
import {MenuItem, PrimeIcons} from "primeng/api";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  items: MenuItem[];

  constructor() {
    this.items = [];
  }

  ngOnInit(): void {
    this.items = [
      { label: 'Home', icon: PrimeIcons.HOME, routerLink: ['home'] },
      { label: 'Flight Plans', icon: PrimeIcons.ALIGN_JUSTIFY, routerLink: ['flight-plans']},
      { label: 'Administration', icon: PrimeIcons.USERS, routerLink: ['administration']}
    ]
  }
}
