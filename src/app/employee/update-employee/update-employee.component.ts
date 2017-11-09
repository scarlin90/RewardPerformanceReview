import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { HttpService, EmployeeDto } from '../../shared/index';
import { environment } from '../../../environments/environment';

import 'rxjs/add/operator/switchMap';
import { Observable } from 'rxjs/Observable';
import { UpdateEmployeeDto } from '../../shared/models/update-employee.dto';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent implements OnInit {

  employee: EmployeeDto;
  httpService: HttpService;

  constructor(httpService: HttpService, private route: ActivatedRoute, private router: Router) {
    this.httpService = httpService;
    this.employee = new EmployeeDto();

  }

  ngOnInit() {
    this.employee.id = parseInt(this.route.snapshot.paramMap.get('employeeId'), 10);
    this.httpService.get<EmployeeDto>(environment.apiRootUrl + environment.employeesUrl + this.employee.id)
    .responseData()
    .subscribe(
      (employeeReturned) => { this.employee = employeeReturned; console.log('Employee Received employeeId: ' + this.employee.id); },
      (err) => { console.error(err.message); },
      () => { console.log('Employees Received employeeId: ' + this.employee.id); }
    );
  }

  updateEmployee(): EmployeeDto {
    console.log(this.employee);
    this.httpService.put<UpdateEmployeeDto, EmployeeDto>(
      environment.apiRootUrl + environment.employeesUrl + this.employee.id.toString(), this.employee)
                    .responseData()
                    .subscribe(
                      (updatedEmployee) => {
                        this.employee = updatedEmployee;
                        console.log('Employee Updated'); },
                      (err) => { console.error(err.message); },
                      () => {
                        this.router.navigate(['/admin-dashboard']);
                        console.log('Employee Updated'); }
                    );
    return this.employee;
  }
}
