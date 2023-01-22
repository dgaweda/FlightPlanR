import {Injectable} from "@angular/core";
import {BaseApiService} from "./base.service";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {AuthenticateResponse} from "../models/authentication/authenticate-response.model";
import {AuthenticateRequest} from "../models/authentication/authenticate-request.model";

@Injectable()
export class AuthenticateService extends BaseApiService {
  constructor(http: HttpClient) {
    super(http);
  }

  authenticate(request: AuthenticateRequest): Observable<AuthenticateResponse> {
    return this.post(this.apiRoutes.authenticate, request);
  }
}
