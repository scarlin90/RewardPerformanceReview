import { NgModule } from '@angular/core';
import { LoginComponent } from './login.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { SharedModule } from '../shared/shared.module';
import { LoginRoutingModule } from './login-routing.module';
import { LocalStorageService } from '../shared/index';
import { AdminDashboardModule } from '../admin-dashboard/admin-dashboard.module';

  @NgModule({
    imports: [

      LoginRoutingModule,
      FormsModule,
      HttpModule,
      AdminDashboardModule
    ],
    providers: [LocalStorageService],
    declarations: [LoginComponent, DashboardComponent],
    exports: [
    LoginComponent
    ]
  })
  export class LoginModule { }
