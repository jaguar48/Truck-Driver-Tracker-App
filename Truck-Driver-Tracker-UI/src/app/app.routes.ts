
import { Routes } from '@angular/router';
import { TruckDriveComponent } from './truckdrive/truck-drive/drivers-list.component';
import { TruckdriverlocComponent } from './truckdrive/truckdriverloc/truckdriverloc.component';
import { TruckLocComponent } from './truckdrive/truck-loc/truck-loc.component';
import { CaculateDistanceComponent } from './truckdrive/caculate-distance/caculate-distance.component';

export const routes: Routes = [


    { path: '', component: TruckDriveComponent  }, 
    // { path: 'movie-details/:id', component: MovieDetailsComponent }, 
   { path: 'truck', component: TruckdriverlocComponent }, 

    { path: 'truck-location', component: TruckLocComponent },
    { path: 'distance', component: CaculateDistanceComponent },
    { path: '**', redirectTo: '', pathMatch: 'full' }
   
];

  
