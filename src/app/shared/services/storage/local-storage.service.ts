import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class LocalStorageService {

  constructor() { }

  get<T>(key: string): Observable<T> {
    const observable = Observable.create((observer: Subject<T>) => {

      if (key === undefined) {
          observer.error(new Error('Specified key is undefined' + key));
          return;
      }

      const item = localStorage.getItem(key) !== undefined ? JSON.parse(localStorage.getItem(key)) as T : undefined;

      if (item === undefined) {
          observer.error(new Error('Specified key ' + key + ' does not exist in Local Storage'));
          return;
      }

      observer.next(item);
    });

  return observable;

  }

}
