import { Component, OnInit } from '@angular/core';
import { TruckService } from '../../Service/truck-service.service';
import { CommonModule } from '@angular/common';
import { TruckLocation } from '../../_interface/driver-truck-location';

@Component({
  selector: 'app-truckdriverloc',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './truckdriverloc.component.html',
  styleUrl: './truckdriverloc.component.scss'
})
export class TruckdriverlocComponent implements OnInit{

  truckdriverList: TruckLocation [] = [];
  currentPage: number = 1;
  itemsPerPage: number = 10; 

  constructor(private truckdriveservice: TruckService ) { }

  ngOnInit(): void {
    this.getTruckDriverList();
  }

  getTruckDriverList(): void {
    this.truckdriveservice.getTruckDriverLocation  ().subscribe(
      (location: TruckLocation []) => {
        this.truckdriverList  = location ;
      },
      (error) => {
        console.error('Error fetching latest drivers queries:', error);
      }
    );
  }

  onPageChange(page: number): void {
    this.currentPage = page;
  }

  get paginatedTruckDriverList():TruckLocation[] {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    const endIndex = startIndex + this.itemsPerPage;
    return this.truckdriverList.slice(startIndex, endIndex);
  }

}
