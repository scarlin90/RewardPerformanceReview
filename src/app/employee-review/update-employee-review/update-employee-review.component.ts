import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { EmployeeDto, HttpService } from '../../shared/index';
import { UpdateEmployeeReviewDto } from '../../shared/models/update-employee-review.dto';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeReviewDto } from '../../shared/models/employee-review.dto';

@Component({
  selector: 'app-update-employee-review',
  templateUrl: './update-employee-review.component.html',
  styleUrls: ['./update-employee-review.component.css']
})
export class UpdateEmployeeReviewComponent implements OnInit {

  employee: EmployeeDto;
  updateEmployeeReviewDto: UpdateEmployeeReviewDto;
  httpService: HttpService;

  constructor(httpService: HttpService, private route: ActivatedRoute, private router: Router) {
    this.httpService = httpService;
    this.employee = new EmployeeDto();
    this.updateEmployeeReviewDto = new UpdateEmployeeReviewDto();
  }

  ngOnInit() {
    this.employee.id = parseInt(this.route.snapshot.paramMap.get('employeeId'), 10);
    this.updateEmployeeReviewDto.id = parseInt(this.route.snapshot.paramMap.get('employeeReviewId'), 10);

    this.httpService.get<EmployeeReviewDto>(
      environment.apiRootUrl + environment.employeesUrl + this.employee.id.toString() +
      '/' + environment.employeesReviewsUrl + this.updateEmployeeReviewDto.id)
    .responseData()
    .subscribe(
      (employeeReviewReturned) => {
        this.updateEmployeeReviewDto = employeeReviewReturned;
        console.log('Employee Received employeeId: ' + this.employee.id);
      },
      (err) => { console.error(err.message); },
      () => { console.log('Employees Received employeeId: ' + this.employee.id); }
    );
  }

  updateEmployeeReview(): EmployeeReviewDto {
    console.log(this.employee);
    this.httpService.put<UpdateEmployeeReviewDto, EmployeeReviewDto>(
      environment.apiRootUrl + environment.employeesUrl + this.employee.id.toString() +
      '/' + environment.employeesReviewsUrl + this.updateEmployeeReviewDto.id, this.updateEmployeeReviewDto)
                    .responseData()
                    .subscribe(
                      (updatedEmployeeReview) => {
                        this.updateEmployeeReviewDto = updatedEmployeeReview;
                        console.log('Employee Review Updated'); },
                      (err) => { console.error(err.message); },
                      () => {
                        this.router.navigate(['/admin-dashboard/view-employee-reviews/' + this.employee.id]);
                        console.log('Employee Review Updated'); }
                    );
    return this.updateEmployeeReviewDto;
  }

}
