import { Component, OnInit } from '@angular/core';
import {MenuItem, PrimeIcons} from "primeng/api";
import {AccountService} from "../../services/account.service";
import {User} from "../../models/user.model";
import {Router} from "@angular/router";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  items: MenuItem[];
  isUserLoggedIn: boolean = false;
  protected user: User | null;

  constructor(private accountService: AccountService, private router: Router) {
    this.items = [];
    this.user = null;
  }

  ngOnInit(): void {
    this.items = [
      { label: 'Home', icon: PrimeIcons.HOME, routerLink: ['home'] },
      { label: 'Flight Plans', icon: PrimeIcons.ALIGN_JUSTIFY, routerLink: ['flight-plans']},
      { label: 'Administration', icon: PrimeIcons.USERS, routerLink: ['administration']}
    ]
    this.userIsLoggedIn();
  }

  protected userIsLoggedIn(): void {
    this.accountService.getCurrentUser()
      .subscribe((user: User | null) => {
        this.isUserLoggedIn = user != null;
        if(this.isUserLoggedIn) {
          this.user = user;
          this.redirectToHomePage();
        }
      });
  }

  protected logOut(): void {
    this.accountService.logout();
  }

  public redirectToHomePage(): void {
    this.router.navigate(['home']);
  }
}
