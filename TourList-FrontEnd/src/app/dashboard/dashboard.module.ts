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

import { DragulaModule } from 'ng2-dragula';

import { RootComponent } from './root/root.component';
import { TourListComponent } from './tour-list/tour-list.component';
import { TourFormComponent } from './tour-form/tour-form.component';
import { HeaderComponent } from './header/header.component';
import { AuthGuard } from '../auth.guard';
import { routing } from './dashboard.routing';
import { AuthenticationInterceptor } from '../AuthenticationInterceptor';
import { TourService } from './shared/services/tour/tour.service';
import { ClientService } from './shared/services/client/client.service';
import { ExcursionService } from './shared/services/excursion/excursion.service';
import { ExcursionSightService } from './shared/services/excursion-sight/excursion-sight.service';

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
    DragulaModule.forRoot(),
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
    TourService,
    ClientService,
    ExcursionService,
    ExcursionSightService,
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
