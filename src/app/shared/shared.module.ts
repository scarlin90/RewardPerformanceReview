import { NgModule } from '@angular/core';
import { HttpService } from './services/index';
import { HttpModule } from '@angular/http';

@NgModule({
  providers: [HttpService],
  imports: [
    HttpModule,
    SharedModule,
  ],
})
export class SharedModule { }
