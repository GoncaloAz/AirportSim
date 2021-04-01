import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaneRequestsComponent } from './plane-requests.component';

describe('PlaneRequestsComponent', () => {
  let component: PlaneRequestsComponent;
  let fixture: ComponentFixture<PlaneRequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlaneRequestsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlaneRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
