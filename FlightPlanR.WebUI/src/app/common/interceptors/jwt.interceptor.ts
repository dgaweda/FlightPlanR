import {Injectable} from "@angular/core";
import {HttpInterceptor} from "@angular/common/http";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private accountService: Account) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return undefined;
  }

}
