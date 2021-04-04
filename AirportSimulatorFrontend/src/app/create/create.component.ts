import { Component, OnInit } from '@angular/core';
import { RequestService } from '../services/request.service';
import { Flight } from '../shared/Flight';
import { Request } from '../shared/Request';


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers:[]
})
export class CreateComponent implements OnInit {

  types = [
    {type: "Landing Request"},
    {type: "Departure Request"},
    {type: "Landing Schedule Request"},
    {type: "Request Departure Request"},
  ]

  time: any;
  timeToSend: Date;
  date:string;
  meridian:boolean = true;
  CurrentDate = new Date();
  RequestTimeDate = new Date();
  request = new Request();
  flight = new Flight();

  constructor(private _requestService: RequestService) { }

  ngOnInit(): void {
  }

  addRequest(){

    //adding the flight code with two way binding in html
    this.request.flight = this.flight;

    var e = (document.getElementById("tipoRequestSelector")) as HTMLSelectElement;
    var sel = e.selectedIndex;
    var opt = e.options[sel];

    var type =(<HTMLOptionElement>opt).text;
    this.request.type = type;

    
    //Date for when the request is for
    //this.request.time = new Date(this.CurrentDate.getFullYear(),this.CurrentDate.getMonth(),this.CurrentDate.getDay(),this.time.hour,this.time.minute,this.time.second);

    this.RequestTimeDate.setFullYear(this.CurrentDate.getFullYear());
    this.RequestTimeDate.setMonth(this.CurrentDate.getMonth());
    this.RequestTimeDate.setDate(this.CurrentDate.getDate());
    this.RequestTimeDate.setHours(this.time.hour);
    this.RequestTimeDate.setMinutes(this.time.minute);
    this.RequestTimeDate.setSeconds(this.time.second);
    //console.log(this.CurrentDate);
    //console.log(this.RequestTimeDate);

    //Default false since it was not aproved yet
    this.request.aproved=false;

    //Date and time when request was created and for  what time request is
    this.request.created = this.CurrentDate;
    this.request.time = this.RequestTimeDate;

    //console.log(this.request.created);
    //console.log(this.request.time);
    this._requestService.addRequest(this.request).subscribe(data => {console.log(data)});
  }

  toggleMeridian(){
    console.log(this.CurrentDate);
    if(this.meridian){
      this.meridian = false;
    }else{
      this.meridian = true;
    }
  }

}
