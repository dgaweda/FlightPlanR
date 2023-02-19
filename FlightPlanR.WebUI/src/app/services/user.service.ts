import {Injectable} from "@angular/core";
import {BaseApiService} from "./base.service";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {User} from "../models/user.model";

@Injectable()
export class UserService extends BaseApiService {
  constructor(http: HttpClient) {
    super(http);
  }

  getById(id: string): Observable<User> {
    return this.get(this.apiRoutes.user.getById.replace('id', id));
  }

  getByUsername(username: string): Observable<User> {
    return this.get(this.apiRoutes.user.getByUserName, username);
  }

  updateUser(id: string, userData: User): Observable<void> {
    return this.put(this.apiRoutes.user.update.setApiRouteId(id), userData);
  }

  removeUser(id: string): Observable<void> {
    return this.delete(this.apiRoutes.user.remove.setApiRouteId(id));
  }
}
