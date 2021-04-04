import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Request } from '../shared/Request';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
  })
};

@Injectable({providedIn:'root'})

export class RequestService {

  constructor(private _http: HttpClient) { }

  getRequests(pageIndex: number, pageSize: number) {
    return this._http.get('https://localhost:5001/Request/AllRequests/' + pageIndex + '/' + pageSize).pipe();
  }

  addRequest(request: Request){

    //Formating Dates
    var time = request.time.getFullYear().toString() +"-"+request.time.getMonth().toString()+"-"+request.time.getDay().toString()+"T"+
               request.time.getHours().toString()+":"+request.time.getMinutes().toString()+":"+request.time.getSeconds().toString();

    var created = request.created.getFullYear().toString() +"-"+request.created.getMonth().toString()+"-"+request.created.getDay().toString()+"T"+
                  request.created.getHours().toString()+":"+request.created.getMinutes().toString()+":"+request.created.getSeconds().toString();

    
    const body= JSON.stringify(request);
    const bodyParsed = JSON.parse(body);

    bodyParsed.time = time;
    bodyParsed.created = created;

    if(bodyParsed.type == "Landing Request"){
      bodyParsed.flight.status = "Requesting to Land";
    }else if(bodyParsed.type == "Departure Request"){
      bodyParsed.flight.status = "Requesting to Departure";
    }else if(bodyParsed.type == "Landing Schedule Request"){
      bodyParsed.flight.status = "Requesting Schedule to Land";
    }else if (bodyParsed.type == "Request Departure Request"){
      bodyParsed.flight.status = "Requesting Schedule to Depart";
    }

    const bodyToSend = JSON.stringify(bodyParsed);
    console.log(bodyToSend);
    
    return this._http.post('https://localhost:5001/Request/CreateRequest', bodyToSend,httpOptions);
  }

}