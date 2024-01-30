import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { TruckService } from '../../Service/truck-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-caculate-distance',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './caculate-distance.component.html',
  styleUrl: './caculate-distance.component.scss'
})
export class CaculateDistanceComponent implements OnInit {


distance: number | null = null;
  distanceForm: FormGroup;

  constructor(private truckService: TruckService, private fb: FormBuilder, private router: Router) {
    this.distanceForm = this.fb.group({
      truckId: [''],
      staticLat: ['', Validators.required],
      staticLon: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    
  }

  onSubmit(): void {
    if (this.distanceForm.valid) {
      const { truckId, staticLat, staticLon } = this.distanceForm.value;
     
      this.truckService.calculateDistance(truckId, staticLat, staticLon).subscribe(
        (distance: number) => {
          this.distance = distance;
        },
        (error) => {
          console.error('Error fetching distance:', error);
        }
      );
    }
  }

  goBack(): void {
    this.router.navigate(['/']); 
  }
}