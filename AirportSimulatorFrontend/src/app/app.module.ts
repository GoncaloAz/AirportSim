import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router'
import { BrowserModule } from '@angular/platform-browser';
import{ HttpClientModule} from '@angular/common/http';
import {appRoutes} from '../routes';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { PlaneRequestsComponent } from './plane-requests/plane-requests.component';
import { PlaneRequestsHistoryComponent } from './plane-requests-history/plane-requests-history.component';
import { PaginationComponent } from './pagination/pagination.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PlaneRequestsComponent,
    PlaneRequestsHistoryComponent,
    PaginationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
