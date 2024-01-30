import { Component, OnInit } from '@angular/core';
import { Truck } from '../../_interface/truck';
import { TruckService } from '../../Service/truck-service.service';
import { CommonModule } from '@angular/common';
import { TruckdriverlocComponent } from '../truckdriverloc/truckdriverloc.component';

@Component({
  selector: 'app-truck-list',
  standalone: true,
  imports: [CommonModule, TruckdriverlocComponent],
  templateUrl: './truck-list.component.html',
  styleUrl: './truck-list.component.scss'
})
export class TruckListComponent implements OnInit {

  truckList: Truck [] = [];
  currentPage: number = 1;
  itemsPerPage: number = 10; 

  constructor(private truckdriveservice: TruckService) { }

  ngOnInit(): void {
    this.getTruckList();
  }

  getTruckList(): void {
    this.truckdriveservice.getTrucks ().subscribe(
      (truck: Truck[]) => {
        this.truckList  = truck ;
      },
      (error) => {
        console.error('Error fetching latest drivers queries:', error);
      }
    );
  }

  onPageChange(page: number): void {
    this.currentPage = page;
  }

  get paginatedTruckList(): Truck[] {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    return this.truckList .slice(startIndex, endIndex);
  }
}