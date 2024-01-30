import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { LocationDto } from '../../_interface/locations';
import { TruckService } from '../../Service/truck-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-truck-loc',
  standalone: true,
  imports: [FormsModule, CommonModule, ReactiveFormsModule],
  templateUrl: './truck-loc.component.html',
  styleUrl: './truck-loc.component.scss'
})

export class TruckLocComponent implements OnInit{


  location: LocationDto | null = null;
  locationForm: FormGroup;
  
  constructor(private truckService: TruckService, private fb: FormBuilder, private router: Router) {
    this.locationForm = this.fb.group({
      truckId: ['', Validators.required],
      driverId: ['', Validators.required],
    });
  }
  ngOnInit(): void {
   
  }

  onSubmit(): void {
    if (this.locationForm.valid) {
      const { truckId, driverId } = this.locationForm.value;
      this.truckService.getLocation(truckId, driverId).subscribe(
        (location: LocationDto) => {
          this.location = location;
        },
        (error) => {
          console.error('Error fetching location:', error);
        }
      );
    }
  }
  goBack(): void {
    this.router.navigate(['/']); 
  }
}

