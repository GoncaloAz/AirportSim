import { Component, OnInit } from '@angular/core';
import { Flight } from '../shared/Flight'
import { Request } from '../shared/Request'
import { Runway } from '../shared/Runway'
import { RequestService } from '../services/request.service';
import { RunwayService } from '../services/runway.service';
import { FlightService } from '../services/flight.service';

@Component({
  selector: 'app-plane-requests',
  templateUrl: './plane-requests.component.html',
  styleUrls: ['./plane-requests.component.css']
})
export class PlaneRequestsComponent implements OnInit {

  constructor(private _requestData: RequestService, private _runwayData: RunwayService, private _flightData: FlightService) { }

  requests: Request[] = [
  ]

  flights: Flight[] = [
  ];

  runway: Runway;
  runwayStatus: string;
  aproveMessage:any;

  ngOnInit(): void {
    this.getAllActiveRequests();
    this.getRunwayData();
    this.getAllFlights();
    
  }
  
  getRunwayData():void {
    this._runwayData.getRunwayInfo()
      .subscribe((res: any) => { 
        console.log("Result from runway: ", res); 
        this.runway = res ;
        console.log(this.runway)

        if(this.runway.available){
          this.runwayStatus = "Runway Status: <div>Available</div>";
        }else{
          this.runwayStatus = "RunwayStatus: Unavailable"
        }
      })
  }
  getAllActiveRequests(): void {
    this._requestData.getActiveRequests()
      .subscribe((res : any) => {
        console.log('Result from getRequests: ', res);
        this.requests = res;
        console.log(this.requests);
    })
  }

  getAllFlights(): void{
    this._flightData.getAllFlights()
      .subscribe((res : any) => {
        console.log('Result from getAllFlights:', res);
        this.flights = res;
        console.log(this.flights);
        this.flights.shift();
      })
  }

  aproveRequest(request: Request){
    console.log(request);
    this._requestData.aproveRequest(request).subscribe((res : any) => {
      console.log('Result from aproveFlight: ', res);
      this.aproveMessage = res;
    })
  }

  
}
