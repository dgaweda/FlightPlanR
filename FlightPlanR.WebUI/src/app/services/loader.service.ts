import {Injectable} from "@angular/core";
import {BehaviorSubject, Observable} from "rxjs";

@Injectable({ providedIn: 'root' })
export class LoaderService {
  private isLoading$: BehaviorSubject<boolean>;

  constructor() {
    this.isLoading$ = new BehaviorSubject<boolean>(false);
  }

  public show(): void {
    this.isLoading$.next(true);
  }

  public hide(): void {
    this.isLoading$.next(false);
  }

  public getLoaderState(): Observable<boolean> {
    return this.isLoading$.asObservable();
  }
}
