import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NoFoundPageComponent } from './no-found-page/no-found-page.component';

import { AccountModule } from './account/account.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { routing } from './app.routing';

@NgModule({
  declarations: [
    AppComponent,
    NoFoundPageComponent 
  ],
  imports: [
    BrowserModule,
    AccountModule,
    DashboardModule,    
    routing
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
