import { Component, OnInit } from '@angular/core';
import { HttpService, LocalStorageService, HttpResponse, AuthenticateRequestDto, EmployeeDto } from '../shared/index';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [LocalStorageService]
})
export class LoginComponent implements OnInit {

  httpService: HttpService;
  localStorageService: LocalStorageService;
  authenticateRequestDto: AuthenticateRequestDto;
  employeeDto: EmployeeDto;

  constructor(httpService: HttpService, localStorageService: LocalStorageService) {
    this.httpService = httpService;
    this.localStorageService = localStorageService;
    this.authenticateRequestDto = new AuthenticateRequestDto();
  }

  ngOnInit() {
  }

  authenticate(authenticateRequestDto: AuthenticateRequestDto) {
    alert('auth ' + authenticateRequestDto.username + ' ' + authenticateRequestDto.password);
  }

}


