import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaneRequestsHistoryComponent } from './plane-requests-history.component';

describe('PlaneRequestsHistoryComponent', () => {
  let component: PlaneRequestsHistoryComponent;
  let fixture: ComponentFixture<PlaneRequestsHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlaneRequestsHistoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlaneRequestsHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
