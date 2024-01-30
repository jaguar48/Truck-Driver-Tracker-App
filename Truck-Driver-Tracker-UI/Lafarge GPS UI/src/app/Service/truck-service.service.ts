import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from './environment-url.service';
import { Observable } from 'rxjs';
import { Driver, Truck } from '../_interface/truck';
import { TruckLocation } from '../_interface/driver-truck-location';
import { LocationDto } from '../_interface/locations';

@Injectable({
  providedIn: 'root'
})
export class TruckService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }


  public getDrivers = (): Observable<Driver[]> => {
    const route = `location/drivers`;
    return this.http.get<Driver[]>(this.createCompleteRoute(route));
  }
  

  public getTrucks = (): Observable<Truck[] > => {
    const route = `location/trucks`;
    return this.http.get<Truck[]>(this.createCompleteRoute(route));
  }

  
  public getTruckDriverLocation = (): Observable<TruckLocation[] > => {
    const route = `location/Truck_Driver_current-location`;
    return this.http.get<TruckLocation[]>(this.createCompleteRoute(route));
  }

  public getLocation = (truckId: string, driverId: number): Observable<LocationDto> => {
    const route = `location/location?truckId=${truckId}&driverId=${driverId}`;
    return this.http.get<LocationDto>(this.createCompleteRoute(route));
  };

  public calculateDistance = (truckId: string, staticLat: number, staticLon: number): Observable<number> => {
    const route = `location/distance?truckId=${truckId}&staticLat=${staticLat}&staticLon=${staticLon}`;
    return this.http.get<number>(this.createCompleteRoute(route));
  };
  

  private createCompleteRoute = (route: string) => {
    return `${this.envUrl.urlAddress}/${route}`;
  };

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
  }

}
