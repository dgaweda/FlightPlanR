import { Component, OnInit } from '@angular/core';
import {MegaMenuItem, MenuItem, PrimeIcons} from "primeng/api";
import {AccountService} from "../../services/account.service";
import {User} from "../../models/user.model";
import {Router} from "@angular/router";
import {BaseComponent} from "../../common/base.component";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent extends BaseComponent implements OnInit {
  pages: MenuItem[];
  userMenu: MenuItem[];
  protected user: User | null;

  constructor(private accountService: AccountService, private router: Router) {
    super();
    this.pages = [];
    this.userMenu = [];
    this.user = null;
  }

  ngOnInit(): void {
    this.setPages();
    this.setUserMenu();
    this.userIsLoggedIn();
  }

  protected userIsLoggedIn(): void {
    this.subscribe(this.accountService.getCurrentUser(), {
      next: (user: User | null) => {
        this.user = user;
        if (user) {
          this.redirectToHomePage();
          this.setPages();
        }
      }
    })
  }

  protected logOut(): void {
    this.accountService.logout();
  }

  public redirectToHomePage(): void {
    this.router.navigate(['home']);
  }

  private setUserMenu(): void {
    this.userMenu = [
        { label: 'Log Out',
          icon: PrimeIcons.SIGN_OUT,
          command: () => {
            this.logOut();
            this.setPages();
          }
        },
        { label: 'Profile', icon: PrimeIcons.USER_EDIT}
    ];
  }

  private setPages(): void {
    this.pages = [
      { label: 'Home', icon: PrimeIcons.HOME, routerLink: ['home'] },
      { label: 'Flight Plans', icon: PrimeIcons.ALIGN_JUSTIFY, routerLink: ['flight-plans'], visible: !!this.user},
      { label: 'Administration', icon: PrimeIcons.USERS, routerLink: ['administration'], visible: !!this.user}
    ]
  }
}
