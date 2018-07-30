import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { TourListComponent } from './dashboard/tour-list/tour-list.component';
import { TourFormComponent } from './dashboard/tour-form/tour-form.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AutocampleteWithFilterComponent } from './dashboard/tour-form/autocamplete-with-filter/autocamplete-with-filter.component';
import { DashboardModule } from './dashboard/dashboard.module';
import {
  MatButtonModule,
  MatAutocompleteModule,
  MatTableModule,
  MatDialogModule,
  MatInputModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatSnackBarModule, 
  MatListModule,
  MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material';

import { AccountModule } from './account/account.module'

@NgModule({
  declarations: [
    AppComponent,
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
    MatListModule,

    AccountModule,
    DashboardModule
  ],
  entryComponents: [TourFormComponent, TourListComponent],
  providers: [
    {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false}}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
