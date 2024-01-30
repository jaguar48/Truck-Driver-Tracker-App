import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TruckdriverlocComponent } from './truckdriverloc.component';

describe('TruckdriverlocComponent', () => {
  let component: TruckdriverlocComponent;
  let fixture: ComponentFixture<TruckdriverlocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TruckdriverlocComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TruckdriverlocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
