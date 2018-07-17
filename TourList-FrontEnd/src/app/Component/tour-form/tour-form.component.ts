import { Component, Inject, OnInit } from '@angular/core';
import { TourService } from '../../Service/Tour/tour.service';
import { ExcursionService } from '../../Service/Excursion/excursion.service';
import { ClientService } from '../../Service/Client/client.service';
import { Tour } from '../../Model/tour';
import { Excursion } from '../../Model/excursion';
import { Client } from '../../Model/client';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormControl } from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';

export interface DialogData {
  tour: Tour;
}

@Component({
  selector: 'app-tour-form',
  templateUrl: './tour-form.component.html',
  styleUrls: ['./tour-form.component.css']
})
export class TourFormComponent implements OnInit {

  tour: Tour;
  excursions: Excursion[];
  clients: Client[];

  myControl = new FormControl();
  filteredOptions: Observable<Excursion[]>;

  constructor(
    private excursionService: ExcursionService,
    private clientService: ClientService,
    public dialogRef: MatDialogRef<TourFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  ngOnInit(){    
    this.getAllExcursions();
    this.getAllClients();
    
    this.filteredOptions = this.myControl.valueChanges
      .pipe(
        startWith<string | Excursion>(''),
        map(value => typeof value === 'string' ? value : value.name),
        map(name => name ? this._filter(name) : this.excursions)
      );
  }

  displayFn(excursion?: Excursion): string | undefined {
    return excursion ? excursion.name : undefined;
  }

  private _filter(name: string) : Excursion[] {
    const filterValue = name.toLowerCase();
    return this.excursions.filter(option => option.name.toLowerCase().indexOf(filterValue) === 0);
  }

  getAllExcursions(){
    this.excursionService.getAllExcursions().subscribe(data => this.excursions = data);
  }

  getAllClients(){
    this.clientService.getAllClients().subscribe(data => this.clients = data);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}