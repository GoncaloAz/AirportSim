import { Component, OnInit } from '@angular/core';
import { Flight } from '../shared/Flight'
import { Request } from '../shared/Request'
import { Runway } from '../shared/Runway'
import { RequestService } from '../services/request.service';
import { RunwayService } from '../services/runway.service';

@Component({
  selector: 'app-plane-requests',
  templateUrl: './plane-requests.component.html',
  styleUrls: ['./plane-requests.component.css']
})
export class PlaneRequestsComponent implements OnInit {

  constructor(private _requestData: RequestService, private _runwayData: RunwayService) { }

  requests: Request[] = [
  ]

  flights: Flight[] = [
  ];

  runway: Runway;

  ngOnInit(): void {
    this.getAllActiveRequests();
    this.getRunwayData();
  }
  
  getRunwayData():void {
    this._runwayData.getRunwayInfo()
      .subscribe((res: any) => { 
        console.log("Result from runway: ", res); 
        this.runway = res ;
        console.log(this.runway)
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
}
