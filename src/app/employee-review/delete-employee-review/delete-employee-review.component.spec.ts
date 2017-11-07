import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteEmployeeReviewComponent } from './delete-employee-review.component';

describe('DeleteEmployeeReviewComponent', () => {
  let component: DeleteEmployeeReviewComponent;
  let fixture: ComponentFixture<DeleteEmployeeReviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteEmployeeReviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteEmployeeReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});
