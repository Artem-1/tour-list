import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';

import { TourService } from '../shared/services/tour/tour.service';
import { ExcursionService } from '../shared/services/excursion/excursion.service';
import { ExcursionSightService } from '../shared/services/excursion-sight/excursion-sight.service';
import { ClientService } from '../shared/services/client/client.service';
import { Tour } from '../shared/models/tour';
import { Excursion } from '../shared/models/excursion';
import { ExcursionSight } from '../shared/models/excursion-sight';
import { Client } from '../shared/models/client';
import { FormControl, Validators } from '../../../../node_modules/@angular/forms';
import { Observable } from '../../../../node_modules/rxjs';
import { IOption } from '../shared/models/IOption';
import { startWith, map } from '../../../../node_modules/rxjs/operators';

@Component({
  selector: 'app-tour-form',
  templateUrl: './tour-form.component.html',
  styleUrls: ['./tour-form.component.css']
})
export class TourFormComponent implements OnInit {

  tour: Tour;
  formMode: boolean = false;
  excursions: Excursion[];
  clients: Client[];
  excursionSights: ExcursionSight[];
  inputedSight: string;

  myControlSight = new FormControl('', Validators.nullValidator);
  filteredOptions: Observable<IOption[]>;

  constructor(
    private tourService: TourService,
    private excursionService: ExcursionService,
    private excursionSightService: ExcursionSightService,
    private clientService: ClientService,
    public dialogRef: MatDialogRef<TourFormComponent>,
    public snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: Tour) {}

  ngOnInit() {
    if(this.data != null) {
      this.formMode = false;
      this.tour = this.data;
    }
    else {
      this.formMode = true;
      this.tour = {
        date: new Date,
        client: {name: ""},
        excursion: {name: "", excursionSights: []},
        excursionSights: [] };
    }
    this.getAllExcursions();
    this.getAllClients();
    this.getAllExcursionSights();

    this.filteredOptions = this.myControlSight.valueChanges
      .pipe(
        startWith<string | IOption>(''),
        map(value => typeof value === 'string' ? value : value.name),
        map(name => name ? this._filter(name) : this.excursionSights)
      );
  }
  
  private _filter(name: string) : IOption[] {
    const filterValue = name.toLowerCase();
    return this.excursionSights
      .filter(option => option.name.toLowerCase().indexOf(filterValue) === 0);
  }

  displayFn(excursion?: IOption): string | undefined {
    return excursion ? excursion.name : undefined;
  }

  onPushSight() {
    if(this.myControlSight.value == "")
      return;

    this.tour.excursion.excursionSights
      .push( { name: this.onChangeSight() } );
    
    this.myControlSight.setValue('');
  }

  onChangeSight() {
      return (typeof this.myControlSight.value === 'string')
        ? this.myControlSight.value : this.myControlSight.value.name;
  }

  onChangeExcursion($event) {
      this.tour.excursion = (typeof $event === 'string') 
        ? { name: $event, excursionSights: [] } : $event;
  }

  onChangeClient($event) {
      this.tour.client = (typeof $event === 'string')
        ? { name: $event } : $event;
  }

  getAllExcursions() {
    this.excursionService.getAllExcursions()
      .subscribe(data => this.excursions = data);
  }

  getAllClients() {
    this.clientService.getAllClients()
      .subscribe(data => this.clients = data);
  }

  getAllExcursionSights() {
    this.excursionSightService.getAllSights()
      .subscribe(data => this.excursionSights = data);
  }

  removeSight(sight: ExcursionSight) {
    let index = this.tour.excursion.excursionSights.indexOf(sight);
        this.tour.excursion.excursionSights.splice(index, 1);
  }

  save() {
    //this.tour.date.setHours(3);
    var message: string;

    if(this.formMode == true) {
        this.tourService.createTour(this.tour).subscribe();
      message = "New tour was added";
    }
    else {
      this.tourService.updateTour(this.tour).subscribe();
      message = "Tour was edited";
    }

    this.snackBar.open(message, "", {duration: 3000});
  }

  cancel() {
    if(confirm("Are you sure that you want to close popap? Your changing will not be saved."))
      this.dialogRef.close();
  }
}