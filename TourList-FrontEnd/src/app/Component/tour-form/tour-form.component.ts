import { Component, Inject, OnInit } from '@angular/core';
import { TourService } from '../../Service/Tour/tour.service';
import { ExcursionService } from '../../Service/Excursion/excursion.service';
import { ExcursionSightService } from '../../Service/ExcursionSight/excursion-sight.service';
import { ClientService } from '../../Service/Client/client.service';
import { Tour } from '../../Model/tour';
import { Excursion } from '../../Model/excursion';
import { ExcursionSight } from '../../Model/excursion-sight';
import { Client } from '../../Model/client';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-tour-form',
  templateUrl: './tour-form.component.html',
  styleUrls: ['./tour-form.component.css'],
  providers: [TourService, ClientService]
})
export class TourFormComponent implements OnInit {

  tour: Tour;
  formMode: boolean = false;
  excursions: Excursion[];
  clients: Client[];
  excursionSights: ExcursionSight[];
  inputedSight: string;

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
  }
  
  onPushSight() {
    this.tour.excursion.excursionSights
      .push( { name: this.inputedSight } );
  }

  onChangeSight($event) {
      this.inputedSight = (typeof $event === 'string')
        ? $event : $event.name;
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