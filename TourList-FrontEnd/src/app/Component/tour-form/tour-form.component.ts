import { Component, Inject, OnInit } from '@angular/core';
import { TourService } from '../../Service/Tour/tour.service';
import { ExcursionService } from '../../Service/Excursion/excursion.service';
import { ClientService } from '../../Service/Client/client.service';
import { Tour } from '../../Model/tour';
import { Excursion } from '../../Model/excursion';
import { Client } from '../../Model/client';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormControl } from '@angular/forms';
import {map, startWith} from 'rxjs/operators';
import {Observable} from 'rxjs';

export interface DialogData {
  animal: string;
  name: string;
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
  //options: string[] = ['One', 'Two', 'Three'];

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
        startWith(''),
        map(value => this._filter(value))
      );
  }

  private _filter(value: string): Excursion[] {
    const filterValue = value.toLowerCase();
    return this.excursions.filter(option => option.name.toLowerCase().includes(filterValue));
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