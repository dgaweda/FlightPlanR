import { Component } from '@angular/core';
import {AuthenticateRequest} from "../../models/authentication/authenticate-request.model";
import {AccountService} from "../../services/account.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  authenticateRequest: AuthenticateRequest;
  constructor(private accountService: AccountService, private router: Router) {
    this.authenticateRequest = new AuthenticateRequest();
  }

  public login(): void {
    console.log(this.authenticateRequest);
    // this.accountService.authenticate(this.authenticateRequest);
  }

  public redirectToRegister(): void {
    this.router.navigate(['register']);
  }
}
