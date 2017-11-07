import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { IsAdminGuard } from '../shared/index';
import { SharedModule } from '../shared/shared.module';
import { CreateEmployeeComponent } from '../employee/create-employee/create-employee.component';
import { ViewEmployeesComponent } from '../employee/view-employees/view-employees.component';
import { UpdateEmployeeComponent } from '../employee/update-employee/update-employee.component';
import { DeleteEmployeeComponent } from '../employee/delete-employee/delete-employee.component';

const adminDashboardRoutes: Routes = [
    { path: 'admin-dashboard/create-employee', component: CreateEmployeeComponent, canActivate: [IsAdminGuard] },
    { path: 'admin-dashboard/view-employees', component: ViewEmployeesComponent, canActivate: [IsAdminGuard] },
    { path: 'admin-dashboard/update-employee/:employeeId', component: UpdateEmployeeComponent, canActivate: [IsAdminGuard] },
    { path: 'admin-dashboard/delete-employee/:employeeId', component: DeleteEmployeeComponent, canActivate: [IsAdminGuard] },
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
