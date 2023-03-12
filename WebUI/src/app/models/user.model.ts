import {AuthenticateResponse} from "./authentication/authenticate-response.model";

export class User {
  id?: string;
  firstName?: string;
  lastName?: string;
  userName?: string;
  password?: string;
  isAdmin?: boolean;
  token?: string;

  constructor(authResponse: AuthenticateResponse) {
    this.id = authResponse.userId;
    this.firstName = authResponse.firstName;
    this.lastName = authResponse.lastName;
    this.userName = authResponse.userName;
    this.token = authResponse.token;
  }
}
