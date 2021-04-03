import { Component, OnInit } from '@angular/core';
import { Request } from '../shared/Request'
import { RequestService } from '../services/request.service';

@Component({
  selector: 'app-plane-requests-history',
  templateUrl: './plane-requests-history.component.html',
  styleUrls: ['./plane-requests-history.component.css']
})
export class PlaneRequestsHistoryComponent implements OnInit {

  requests: Request[];
  total=0;
  page=1;
  limit=10;
  loading = false;
  constructor(private _requestData: RequestService) { }

  

  ngOnInit(): void {
    this.getAllRequests();
  }

  getAllRequests(): void {
    this._requestData.getRequests(this.page, this.limit)
      .subscribe((res : any) => {
        console.log('Result from getRequests: ', res);
        this.requests = res['page']['data'];
        console.log(this.requests);
        this.total =res['page'].total;
        this.loading = false;

    })
  }

  goToPrevious():void{
    this.page--;
    this.getAllRequests();
  }
  goToNext():void{
    this.page++;
    this.getAllRequests();
  }
  goToPage(n: number): void {
    this.page = n;
    this.getAllRequests();
  }

}
