import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEmployeeReviewComponent } from './create-employee-review.component';

describe('CreateEmployeeReviewComponent', () => {
  let component: CreateEmployeeReviewComponent;
  let fixture: ComponentFixture<CreateEmployeeReviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateEmployeeReviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateEmployeeReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});
