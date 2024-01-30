import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TruckLocComponent } from './truck-loc.component';

describe('TruckLocComponent', () => {
  let component: TruckLocComponent;
  let fixture: ComponentFixture<TruckLocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TruckLocComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TruckLocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
