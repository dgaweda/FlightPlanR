import {Injectable} from "@angular/core";
import {BaseApiService} from "../common/services/base.service";
import {HttpClient} from "@angular/common/http";
import {BehaviorSubject, map, Observable} from "rxjs";
import {AuthenticateResponse} from "../models/authentication/authenticate-response.model";
import {AuthenticateRequest} from "../models/authentication/authenticate-request.model";
import {User} from "../models/user.model";
import {Router} from "@angular/router";
import {LocalStorageService} from "../common/services/local-storage.service";

@Injectable({ providedIn: 'root' })
export class AccountService extends BaseApiService {
  private user$: BehaviorSubject<User | null>;
  public user: Observable<User | null>;

  constructor(
    http: HttpClient,
    private router: Router,
    private localStorageService: LocalStorageService
  ) {
    super(http);
    this.user$ = new BehaviorSubject<User | null>(localStorageService.getUser())
    this.user = this.user$.asObservable();
  }

  public get userValue(): User | null {
    return this.user$.value;
  }

  public authenticate(request: AuthenticateRequest): Observable<User> {
    return this.post<AuthenticateResponse>(this.apiRoutes.account.authenticate, request).pipe(map((authResponse: AuthenticateResponse) => {
      const user = new User(authResponse);
      this.localStorageService.setUser(user);
      this.user$.next(user);
      return user;
    }));
  }

  public logout(): void {
    this.localStorageService.removeUser();
    this.user$.next(null);
    this.router.navigate(['/home']);
  }

  public register(request: User): Observable<string> {
    return this.post<string>(this.apiRoutes.account.register, request);
  }
}
