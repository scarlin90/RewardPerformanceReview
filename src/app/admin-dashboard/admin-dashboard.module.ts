import { NgModule } from '@angular/core';
import { AdminDashboardComponent } from '../admin-dashboard/admin-dashboard.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { SharedModule } from '../shared/shared.module';
import { AdminDashboardRoutingModule } from './admin-dashboard-routing.module';
import { LocalStorageService } from '../shared/index';

  @NgModule({
    imports: [
      AdminDashboardRoutingModule,
      FormsModule,
      HttpModule,
    ],
    declarations: [AdminDashboardComponent],
    exports: [
      AdminDashboardComponent
    ]
  })
  export class AdminDashboardModule { }
