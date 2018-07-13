import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule }    from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { UserComponent } from './Component/User/user.component';
import { TourListComponent } from './Component/tour-list/tour-list.component';
import { TourFormComponent } from './Component/tour-form/tour-form.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatButtonModule, 
  MatAutocompleteModule, 
  MatTableModule, 
  MatDialogModule, 
  MatInputModule, 
  MatDatepickerModule, 
  MatNativeDateModule   
} from '@angular/material';
//import {MatMomentDateModule } from '@angular/material/material';
//import { MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    TourFormComponent,
    TourListComponent    
  ],
  imports: [
    BrowserModule,
    FormsModule, ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule, MatAutocompleteModule, MatTableModule, MatDialogModule,
    MatInputModule, MatDatepickerModule, MatNativeDateModule, //MatMomentDateModule
  ],
  entryComponents: [TourFormComponent, TourListComponent],
  providers: [
    //{provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false}}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
