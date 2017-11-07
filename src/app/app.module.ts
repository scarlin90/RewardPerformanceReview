import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { LoginComponent } from './login/login.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginModule } from './login/login.module';
import { AppRoutingModule } from './app-routing.module';
import { CreateEmployeeComponent } from './employee/create-employee/create-employee.component';
import { ViewEmployeesComponent } from './employee/view-employees/view-employees.component';
import { UpdateEmployeeComponent } from './employee/update-employee/update-employee.component';

const appRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '',   redirectTo: '/login', pathMatch: 'full' },
];

@NgModule({
  declarations: [
    AppComponent,
    CreateEmployeeComponent,
    ViewEmployeesComponent,
    UpdateEmployeeComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    SharedModule,
    LoginModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
