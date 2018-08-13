import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NoFoundPageComponent } from './no-found-page/no-found-page.component';

import { AccountModule } from './account/account.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { routing } from './app.routing';
import { UserService } from './shared/services/user/user.service';

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
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
