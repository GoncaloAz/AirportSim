import { Routes } from '@angular/router';
import { CreateComponent } from './app/create/create.component';
import { PlaneRequestsHistoryComponent } from './app/plane-requests-history/plane-requests-history.component';
import { PlaneRequestsComponent } from './app/plane-requests/plane-requests.component';

export const appRoutes : Routes = [
    {path : "requests", component:  PlaneRequestsComponent},
    {path: "history", component: PlaneRequestsHistoryComponent},
    {path: "create", component: CreateComponent},

    {path:"", redirectTo: "/requests", pathMatch: "full"},
];