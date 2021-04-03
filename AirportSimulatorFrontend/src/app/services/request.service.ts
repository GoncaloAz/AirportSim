import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({providedIn:'root'})

export class RequestService {

  constructor(private _http: HttpClient) { }

  getRequests(pageIndex: number, pageSize: number) {
    return this._http.get('https://localhost:5001/Request/AllRequests/' + pageIndex + '/' + pageSize).pipe();
  }
}