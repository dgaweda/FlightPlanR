import {Component} from '@angular/core';
import {AuthenticateRequest} from "../../models/authentication/authenticate-request.model";
import {AccountService} from "../../services/account.service";
import {Router} from "@angular/router";
import {BaseComponent} from "../../common/base.component";
import {User} from "../../models/user.model";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends BaseComponent {
  authenticateRequest: AuthenticateRequest;

  constructor(private accountService: AccountService, private router: Router) {
    super();
    this.authenticateRequest = new AuthenticateRequest();
  }

  public login(): void {
    this.subscribe(this.accountService.authenticate(this.authenticateRequest), {
      next: (user: User) => console.log(user)
    });
  }

  public redirectToRegister(): void {
    this.router.navigate(['register']);
  }
}
