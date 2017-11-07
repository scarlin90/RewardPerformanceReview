import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { IsAdminGuard } from '../shared/index';
import { SharedModule } from '../shared/shared.module';
import { CreateEmployeeComponent } from '../employee/create-employee/create-employee.component';

const adminDashboardRoutes: Routes = [
    { path: 'admin-dashboard/create-employee', component: CreateEmployeeComponent, canActivate: [
        IsAdminGuard
      ] },
  ];

@NgModule({
  imports: [
    RouterModule.forChild(
      adminDashboardRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class AdminDashboardRoutingModule {

}
