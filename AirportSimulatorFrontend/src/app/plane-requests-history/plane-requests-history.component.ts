import { Component, OnInit } from '@angular/core';
import { Request } from '../shared/Request'

@Component({
  selector: 'app-plane-requests-history',
  templateUrl: './plane-requests-history.component.html',
  styleUrls: ['./plane-requests-history.component.css']
})
export class PlaneRequestsHistoryComponent implements OnInit {

  constructor() { }

  requests: Request[] = [

    {id: 1, flightNumber : "F505", requestType: "Land", timeOfRequest: new Date(2021,4,1,17,5,0)},
    {id: 2, flightNumber : "F504", requestType: "Departure", timeOfRequest: new Date(2021,4,1,17,10,55)},
    {id: 1, flightNumber : "H505", requestType: "Land", timeOfRequest: new Date(2021,4,1,17,11,0)},
    {id: 1, flightNumber : "TP505", requestType: "Land", timeOfRequest: new Date(2021,4,1,17,15,33)},

  ]

  ngOnInit(): void {
  }

}
