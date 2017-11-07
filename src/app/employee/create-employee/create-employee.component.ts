import { Component, OnInit } from '@angular/core';
import { CreateEmployeeDto } from '../../shared/models/create-employee.dto';
import { HttpService, EmployeeDto } from '../../shared/index';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.css']
})
export class CreateEmployeeComponent implements OnInit {

  router: Router;
  createEmployeeDto: CreateEmployeeDto;
  createdEmployeeDto: EmployeeDto;
  httpService: HttpService;

  constructor(httpService: HttpService, router: Router) {
    this.httpService = httpService;
    this.router = router;
    this.createEmployeeDto = new CreateEmployeeDto();
  }

  ngOnInit() {

  }

  createEmployee(createEmployeeDto: CreateEmployeeDto): EmployeeDto {
    this.httpService.post<CreateEmployeeDto, EmployeeDto>(environment.apiRootUrl + environment.employeesUrl, createEmployeeDto)
                    .responseData()
                    .subscribe(
                      (employee) => { this.createdEmployeeDto = employee; console.log('Employee Created'); },
                      (err) => { console.error(err.message); },
                      () => {
                        this.router.navigate(['/admin-dashboard']);
                        console.log('Employee Created'); }
                    );
    return this.createdEmployeeDto;
  }
}
