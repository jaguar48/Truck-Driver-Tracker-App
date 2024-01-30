import { Component, OnInit } from '@angular/core';
import { TruckService} from '../../Service/truck-service.service';
import { Driver } from '../../_interface/truck';
import { CommonModule } from '@angular/common';
import { TruckListComponent } from '../truck-list/truck-list.component';
import { TruckdriverlocComponent } from '../truckdriverloc/truckdriverloc.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-truck-drive',
  standalone: true,
  imports: [CommonModule, TruckListComponent, TruckdriverlocComponent],
  templateUrl: './drivers-list.component.html',
  styleUrl: './drivers-list.scss'
})

export class TruckDriveComponent implements OnInit {
  driversList: Driver[] = [];
  currentPage: number = 1;
  itemsPerPage: number = 10; 

  constructor(private truckdriveservice: TruckService, private router: Router) { }

  ngOnInit(): void {
    this.getDriverList();
  }

  getDriverList(): void {
    this.truckdriveservice.getDrivers().subscribe(
      (drivers: Driver[]) => {
        this.driversList = drivers;
      },
      (error) => {
        console.error('Error fetching latest drivers queries:', error);
      }
    );
  }

  onPageChange(page: number): void {
    this.currentPage = page;
  }

  get paginatedDriversList(): Driver[] {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    return this.driversList.slice(startIndex, endIndex);
  }

  gotoLocateTruck(): void {
    this.router.navigate(['/truck-location']); 
  }

  caculateDistance(): void {
    this.router.navigate(['/distance']); 
  }
}
