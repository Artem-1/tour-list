import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { AppComponent } from './app.component';
import { UserComponent } from './Component/User/user.component';
import { TourListComponent } from './Component/tour-list/tour-list.component';
import { TourFormComponent } from './Component/tour-form/tour-form.component';
//import { UserService } from '../app/Service/User/user.service'

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    TourListComponent,
    TourFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
