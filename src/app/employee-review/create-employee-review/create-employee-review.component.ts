import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { CreateEmployeeReviewDto } from '../../shared/models/create-employee-review.dto';
import { EmployeeReviewDto } from '../../shared/models/employee-review.dto';
import { EmployeeDto, HttpService } from '../../shared/index';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-employee-review',
  templateUrl: './create-employee-review.component.html',
  styleUrls: ['./create-employee-review.component.css']
})
export class CreateEmployeeReviewComponent implements OnInit {

  employee: EmployeeDto;
  createEmployeeReviewDto: CreateEmployeeReviewDto;
  httpService: HttpService;

  constructor(httpService: HttpService, private route: ActivatedRoute, private router: Router) {
    this.httpService = httpService;
    this.employee = new EmployeeDto();
    this.createEmployeeReviewDto = new CreateEmployeeReviewDto();
  }

  ngOnInit() {
    this.employee.id = parseInt(this.route.snapshot.paramMap.get('employeeId'), 10);
  }

  createEmployeeReview(): EmployeeReviewDto {
    console.log(this.employee);
    this.httpService.post<CreateEmployeeReviewDto, EmployeeReviewDto>(
      environment.apiRootUrl + environment.employeesUrl + this.employee.id.toString() +
      '/' + environment.employeesReviewsUrl, this.createEmployeeReviewDto)
                    .responseData()
                    .subscribe(
                      (createdEmployeeReview) => {
                        this.createEmployeeReviewDto = createdEmployeeReview;
                        console.log('Employee Review Created'); },
                      (err) => { console.error(err.message); },
                      () => {
                        this.router.navigate(['/admin-dashboard/view-employee-reviews/' + this.employee.id]);
                        console.log('Employee Review Created'); }
                    );
    return this.createEmployeeReviewDto;
  }
}
