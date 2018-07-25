import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { UserComponent } from './Component/User/user.component';
import { TourListComponent } from './Component/tour-list/tour-list.component';
import { TourFormComponent } from './Component/tour-form/tour-form.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AutocampleteWithFilterComponent } from './Component/tour-form/autocamplete-with-filter/autocamplete-with-filter.component';

import {
  MatButtonModule,
  MatAutocompleteModule,
  MatTableModule,
  MatDialogModule,
  MatInputModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatSnackBarModule,
  MatListModule
} from '@angular/material';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    TourFormComponent,
    TourListComponent,
    AutocampleteWithFilterComponent    
  ],
  imports: [
    BrowserModule,
    FormsModule, ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatAutocompleteModule,
    MatTableModule,
    MatDialogModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSnackBarModule,
    MatListModule
  ],
  entryComponents: [TourFormComponent, TourListComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
