import { NgModule } from '@angular/core';
import { LoginComponent } from './login.component';
import { AdminDashboardComponent } from '../admin-dashboard/admin-dashboard.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { SharedModule } from '../shared/shared.module';
import { LoginRoutingModule } from './login-routing.module';
import { LocalStorageService } from '../shared/index';

  @NgModule({
    imports: [

      LoginRoutingModule,
      FormsModule,
      HttpModule,
    ],
    providers: [LocalStorageService],
    declarations: [LoginComponent, AdminDashboardComponent, DashboardComponent],
    exports: [
    LoginComponent
    ]
  })
  export class LoginModule { }
