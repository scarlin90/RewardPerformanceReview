import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpService } from './services/index';

@NgModule({
  providers: [HttpService],
})
export class SharedModule { }
