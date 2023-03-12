import {Injectable, OnDestroy} from "@angular/core";
import {Observable, PartialObserver, Subject, Subscription, takeUntil} from "rxjs";

@Injectable()
export abstract class BaseComponent implements OnDestroy {
  private unsubscribe: Subject<void>;

  protected constructor() {
    this.unsubscribe = new Subject<void>();
  }

  protected subscribe<T>(observable: Observable<T>, observer?: PartialObserver<T>): Subscription {
    return observable
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(observer);
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }
}
