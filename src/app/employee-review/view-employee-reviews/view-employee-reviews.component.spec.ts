import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewEmployeeReviewsComponent } from './view-employee-reviews.component';

describe('ViewEmployeeReviewsComponent', () => {
  let component: ViewEmployeeReviewsComponent;
  let fixture: ComponentFixture<ViewEmployeeReviewsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewEmployeeReviewsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewEmployeeReviewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});
