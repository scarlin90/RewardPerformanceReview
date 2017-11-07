import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { EmployeeReviewDto } from '../../shared/models/employee-review.dto';
import { HttpService, EmployeeDto } from '../../shared/index';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-employee-reviews',
  templateUrl: './view-employee-reviews.component.html',
  styleUrls: ['./view-employee-reviews.component.css']
})
export class ViewEmployeeReviewsComponent implements OnInit {

  employee: EmployeeDto;
  employeeReviews: EmployeeReviewDto[];
  httpService: HttpService;
  router: Router;

  constructor(httpService: HttpService, private route: ActivatedRoute) {
    this.httpService = httpService;
    this.employee = new EmployeeDto();
    this.employeeReviews = [];
  }

  ngOnInit() {
    this.employee.id = parseInt(this.route.snapshot.paramMap.get('employeeId'), 10);
    this.httpService.get<EmployeeReviewDto[]>
                (environment.apiRootUrl + environment.employeesUrl + this.employee.id + '/' + environment.employeesReviewsUrl)
    .responseData()
    .subscribe(
      (employeeReviewsReturned) => { this.employeeReviews = employeeReviewsReturned; console.log('Employees Reviews Received'); },
      (err) => { console.error(err.message); },
      () => { console.log('Employees Reviews Received'); }
    );
  }

}
