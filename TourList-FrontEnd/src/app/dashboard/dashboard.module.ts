import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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

import { RootComponent } from './root/root.component';
import { TourListComponent } from './tour-list/tour-list.component';
import { TourFormComponent } from './tour-form/tour-form.component';
import { HeaderComponent } from './header/header.component';
import { AuthGuard } from '../auth.guard';
import { routing } from './dashboard.routing';
import { AuthenticationInterceptor } from '../AuthenticationInterceptor';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
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
    routing
  ],
  declarations: [
    RootComponent,
    HeaderComponent,
    TourListComponent,
    TourFormComponent,
  ],
  entryComponents: [TourFormComponent],
  providers:[
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthenticationInterceptor,
      multi: true,
    },
    {
      provide: MAT_DIALOG_DEFAULT_OPTIONS, 
      useValue: { hasBackdrop: false }
    }
  ]
})
export class DashboardModule { }
