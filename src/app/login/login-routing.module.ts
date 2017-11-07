import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { LoginComponent } from './login.component';
import { AdminDashboardComponent } from '../admin-dashboard/admin-dashboard.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { IsAdminGuard } from '../shared/index';
import { SharedModule } from '../shared/shared.module';


const loginRoutes: Routes = [
    { path: 'admin-dashboard', component: AdminDashboardComponent, canActivate: [
        IsAdminGuard
      ] },
    { path: 'dashboard', component: DashboardComponent },
  ];

@NgModule({
  imports: [
    RouterModule.forChild(
        loginRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class LoginRoutingModule {

}
