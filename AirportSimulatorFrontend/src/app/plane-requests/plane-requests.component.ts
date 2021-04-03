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
  ]

  flights: Flight[] = [

    {id:1, flightCode : "F555", status:"Shedule Landing"},
    {id:2, flightCode : "F554", status:"Departure"}

  ];

  ngOnInit(): void {
  }

}
