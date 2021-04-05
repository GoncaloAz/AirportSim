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

  alertSuccess: boolean = false;
  alertError: boolean = false;
  alertDenySuccess: boolean = false;
  alertSuccessDeny: boolean = false;
  runway: Runway;
  runwayStatus: string;
  aproveMessage:any;
  denyMessage: any;


  ngOnInit(): void {
    this.alertSuccess = false;
    this.alertError = false;
    this.getAllActiveRequests();
    this.getRunwayData();
    this.getAllFlights();
    setInterval(() => {
      this.refresh();
    }, 15000)
    
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
          this.runwayStatus = "RunwayStatus: Unavailable. Current Flight Occupying: " + this.runway.flightOnRunway
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

      if(res.code == 1){
        this.alertSuccess = true;
      }else{
        this.alertError = true;
      }

      setInterval(() => {
        window.location.reload();
      }, 2000)

      
    })
  }

  denyRequest(request : Request){
    console.log(request);
    this._requestData.denyRequest(request).subscribe((res : any) => {
      console.log('Request from denyFllight', res);
      this.denyMessage = res;
      this.alertDenySuccess= true;
      
      setInterval(() => {
        window.location.reload();
      }, 2000)
      
    })
  }

  closeAlert(){
    this.alertSuccess=false;
    this.alertError=false;
  }

  refresh(){
    this._runwayData.clearRunway().subscribe(res => {});
    window.location.reload(); 
  }
}
