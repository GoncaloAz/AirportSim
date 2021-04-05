import { Component, OnInit } from '@angular/core';
import { RunwayService } from '../services/runway.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private _runwayData: RunwayService) { }

  ngOnInit(): void {
    setInterval(() => {
      this.clearRunway();
    }, 15000)
  }

  clearRunway(){
    this._runwayData.clearRunway().subscribe(res => {});
  }

}
