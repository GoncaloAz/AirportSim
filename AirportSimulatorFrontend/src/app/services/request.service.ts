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

export class RequestService {

  constructor(private _http: HttpClient) { }

  getRequests(pageIndex: number, pageSize: number) {
    return this._http.get('https://localhost:5001/Request/AllRequests/' + pageIndex + '/' + pageSize).pipe();
  }

  getActiveRequests(){
    return this._http.get("https://localhost:5001/Request/AllRequests/Active").pipe();
  }

  addRequest(request: Request):Observable<any>{

    //Formating Dates
    console.log(request.time);
    console.log(request.time.getMonth());
    var time = DateFormatter(request.time);

    var created = DateFormatter(request.created);

    console.log(time);
    console.log(created)
    
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
    
    return this._http.post('https://localhost:5001/Request/CreateRequest', 
    {
      "flight":{
              "flightCode":request.flight.flightCode,
              "status": bodyParsed.flight.status
              },
      "type": request.type,
      "time": time,
      "aproved": false,
      "active": true,
      "created":created
    },
    httpOptions);
  }

  aproveRequest(request : Request){

    return this._http.put("https://localhost:5001/Request/AproveRequest",request,httpOptions);
    
  }

  denyRequest(request : Request){

    return this._http.put("https://localhost:5001/Request/DenyRequest",request,httpOptions);
    
  }

}