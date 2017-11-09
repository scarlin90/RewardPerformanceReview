import { NgModule } from '@angular/core';
import { AdminDashboardComponent } from '../admin-dashboard/admin-dashboard.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { SharedModule } from '../shared/shared.module';
import { AdminDashboardRoutingModule } from './admin-dashboard-routing.module';
import { LocalStorageService } from '../shared/index';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ViewEmployeesComponent } from '../employee/view-employees/view-employees.component';
import { BrowserModule } from '@angular/platform-browser';

  @NgModule({
    imports: [
      BrowserModule,
      BsDropdownModule.forRoot(),
      AdminDashboardRoutingModule,
      FormsModule,
      HttpModule,
    ],
    declarations: [ViewEmployeesComponent, AdminDashboardComponent],
    exports: [
      AdminDashboardComponent,
    ]
  })
  export class AdminDashboardModule { }
