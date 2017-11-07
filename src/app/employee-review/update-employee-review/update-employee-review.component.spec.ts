import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateEmployeeReviewComponent } from './update-employee-review.component';

describe('UpdateEmployeeReviewComponent', () => {
  let component: UpdateEmployeeReviewComponent;
  let fixture: ComponentFixture<UpdateEmployeeReviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateEmployeeReviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateEmployeeReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});
