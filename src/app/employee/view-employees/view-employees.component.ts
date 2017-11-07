import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { EmployeeDto, HttpService } from '../../shared/index';

@Component({
  selector: 'app-view-employees',
  templateUrl: './view-employees.component.html',
  styleUrls: ['./view-employees.component.css']
})
export class ViewEmployeesComponent implements OnInit {

  employees: EmployeeDto[];
  httpService: HttpService;

  constructor(httpService: HttpService) {
    this.httpService = httpService;
    this.employees = [];
  }

  ngOnInit() {
    this.httpService.get<EmployeeDto[]>(environment.apiRootUrl + environment.employeesUrl)
    .responseData()
    .subscribe(
      (employeesReturned) => { this.employees = employeesReturned; console.log('Employees Received'); },
      (err) => { console.error(err.message); },
      () => { console.log('Employees Received'); }
    );
  }
}
