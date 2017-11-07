import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { EmployeeDto, HttpService } from '../../shared/index';
import { CreateEmployeeReviewDto } from '../../shared/models/create-employee-review.dto';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeReviewDto } from '../../shared/models/employee-review.dto';

@Component({
  selector: 'app-delete-employee-review',
  templateUrl: './delete-employee-review.component.html',
  styleUrls: ['./delete-employee-review.component.css']
})
export class DeleteEmployeeReviewComponent implements OnInit {

  employee: EmployeeDto;
  employeeReview: EmployeeReviewDto;
  httpService: HttpService;

  constructor(httpService: HttpService, private route: ActivatedRoute, private router: Router) {
    this.httpService = httpService;
    this.employee = new EmployeeDto();
    this.employeeReview = new EmployeeReviewDto();
  }

  ngOnInit() {
    this.employee.id = parseInt(this.route.snapshot.paramMap.get('employeeId'), 10);
    this.employeeReview.id = parseInt(this.route.snapshot.paramMap.get('employeeReviewId'), 10);

    this.httpService.delete(
      environment.apiRootUrl + environment.employeesUrl + this.employee.id.toString() +
      '/' + environment.employeesReviewsUrl + this.employeeReview.id)
                    .responseData()
                    .subscribe(
                      (deletedEmployeeReview) => {
                        console.log('Employee Review Deleted'); },
                      (err) => { console.error(err.message); },
                      () => {
                        this.router.navigate(['/admin-dashboard/view-employee-reviews/' + this.employee.id]);
                        console.log('Employee Review Deleted'); }
                    );
  }
}
