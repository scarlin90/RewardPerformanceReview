import { NgModule } from '@angular/core';
import { HttpService } from './services/index';
import { HttpModule } from '@angular/http';
import { IsAdminGuard } from './index';

@NgModule({
  providers: [HttpService, IsAdminGuard],
  imports: [
    HttpModule,
  ],
})
export class SharedModule { }
