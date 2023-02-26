import {Injectable} from "@angular/core";
import {User} from "../../models/user.model";

@Injectable({ providedIn: 'root' })
export class LocalStorageService {
  public getItem<T>(key: string): T | null {
    const item = localStorage.getItem(key);

    if(item)
      return JSON.parse(item);

    return null;
  }

  public setItem<T>(key: string, value: T): void {
    const jsonValue = JSON.stringify(value);
    localStorage.setItem(key, jsonValue);
  }

  public removeItem(key: string): void {
    localStorage.removeItem(key);
  }

  public getUser(): User | null {
    return this.getItem<User>('user');
  }

  public removeUser(): void {
    this.removeItem('user');
  }

  public setUser(user: User): void {
    this.setItem<User>('user', user);
  }
}
