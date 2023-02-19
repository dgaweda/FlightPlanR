import {Injectable} from "@angular/core";
import {BaseApiService} from "./base.service";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {AuthenticateResponse} from "../models/authentication/authenticate-response.model";
import {AuthenticateRequest} from "../models/authentication/authenticate-request.model";
import {User} from "../models/user.model";

@Injectable()
export class AccountService extends BaseApiService {
  constructor(http: HttpClient) {
    super(http);
  }

  authenticate(request: AuthenticateRequest): Observable<AuthenticateResponse> {
    return this.post(this.apiRoutes.account.authenticate, request);
  }

  register(request: User): Observable<string> {
    return this.post(this.apiRoutes.account.register, request);
  }
}
