import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Request } from '../shared/Request';
import { DateFormatter } from '../utils/dateFormatter';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
  })
};

@Injectable({providedIn:'root'})

export class RunwayService {

  constructor(private _http: HttpClient) { }

  getRunwayInfo() {
    return this._http.get("https://localhost:5001/Runway/Info").pipe();
  }


}