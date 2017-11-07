import { Component, OnInit } from '@angular/core';
import { EmployeeDto, HttpService } from '../../shared/index';
import { environment } from '../../../environments/environment';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-delete-employee',
  templateUrl: './delete-employee.component.html',
  styleUrls: ['./delete-employee.component.css']
})
export class DeleteEmployeeComponent implements OnInit {

  employee: EmployeeDto;
  httpService: HttpService;

  constructor(httpService: HttpService, private route: ActivatedRoute, private router: Router) {
    this.httpService = httpService;
    this.employee = new EmployeeDto();

  }

  ngOnInit() {
    this.employee.id = parseInt(this.route.snapshot.paramMap.get('employeeId'), 10);
    this.httpService.delete(environment.apiRootUrl + environment.employeesUrl + this.employee.id)
    .responseData()
    .subscribe(
      (employeeDeleted) => { console.error('deleted employee ' + this.employee.id); },
      (err) => { console.error(err.message); },
      () => {
        this.router.navigate(['/admin-dashboard/view-employees']);
        console.error('deleted employee ' + this.employee.id); }
    );
  }
}
