import { Component, OnInit } from '@angular/core';
import { Flight } from '../shared/flight'
import { Request } from '../shared/Request'

@Component({
  selector: 'app-plane-requests',
  templateUrl: './plane-requests.component.html',
  styleUrls: ['./plane-requests.component.css']
})
export class PlaneRequestsComponent implements OnInit {

  constructor() { }

  requests: Request[] = [

    {id: 1, flightCode : "F505", requestType: "Land",timeForRequest: new Date(2021,4,1,17,5,0), timeOfRequestCreation: new Date(2021,4,1,17,5,0),aproved:true},
    {id: 2, flightCode : "F504", requestType: "Departure",timeForRequest: new  Date(2021,4,1,17,10,55), timeOfRequestCreation: new Date(2021,4,1,17,10,55),aproved:true},
    {id: 3, flightCode : "H505", requestType: " Shcedule Landing",timeForRequest: new Date(2021,4,1,17,10,0), timeOfRequestCreation: new Date(2021,4,1,16,55,0),aproved:false},
    {id: 4, flightCode : "TP505", requestType: "Schedule Departure",timeForRequest: new Date(2021,4,1,18,30,0), timeOfRequestCreation: new Date(2021,4,1,17,15,0),aproved:true},

  ]

  flights: Flight[] = [

    {id:1, flightCode : "F555", status:"Shedule Landing"},
    {id:2, flightCode : "F554", status:"Departure"}

  ];

  ngOnInit(): void {
  }

}
