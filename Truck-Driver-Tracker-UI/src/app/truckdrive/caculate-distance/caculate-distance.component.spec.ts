import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CaculateDistanceComponent } from './caculate-distance.component';

describe('CaculateDistanceComponent', () => {
  let component: CaculateDistanceComponent;
  let fixture: ComponentFixture<CaculateDistanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CaculateDistanceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CaculateDistanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
