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
    this.request.time = new Date(this.CurrentDate.getFullYear(),this.CurrentDate.getMonth(),this.CurrentDate.getDay(),this.time.hour,this.time.minute,this.time.second);

    //Default false since it was not aproved yet
    this.request.aproved=false;

    //Date and time when request was created
    this.request.created = this.CurrentDate;

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
