import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewEmployeeReviewComponent } from './view-employee-review.component';

describe('ViewEmployeeReviewComponent', () => {
  let component: ViewEmployeeReviewComponent;
  let fixture: ComponentFixture<ViewEmployeeReviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewEmployeeReviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewEmployeeReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});
