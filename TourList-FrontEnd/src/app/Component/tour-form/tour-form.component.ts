import { Component, Inject, OnInit } from '@angular/core';
import { TourService } from '../../Service/Tour/tour.service';
import { ExcursionService } from '../../Service/Excursion/excursion.service';
import { ClientService } from '../../Service/Client/client.service';
import { Tour } from '../../Model/tour';
import { Excursion } from '../../Model/excursion';
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
  nameLabelExcursion: string = "Excursion";
  nameLabelClient: string = "Client";
  excursions: Excursion[];
  clients: Client[];

  constructor(
    private tourService: TourService,
    private excursionService: ExcursionService,
    private clientService: ClientService,
    public dialogRef: MatDialogRef<TourFormComponent>,
    public snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: Tour) {}

  ngOnInit(){
    if(this.data != null) {
      this.tour = this.data;
      this.formMode = false;
    }
    else {
      this.tour = { date: new Date, client: {name: ""}, excursion: {name: "", excursionSights: []}, excursionSights: [] };
      this.formMode = true;
    }
    this.getAllExcursions();
    this.getAllClients();
  }

  onChangeExcursion($event) {
    if(typeof $event === 'string') {
      this.tour.excursion = { name: $event, excursionSights: null };
    }
    else {
      this.tour.excursion = $event;
    }
  }

  onChangeClient($event) {
    if(typeof $event === 'string') {
      this.tour.client = { name: $event };
    }
    else {
      this.tour.client = $event;
    }
  }

  getAllExcursions(){
    this.excursionService.getAllExcursions().subscribe(data => this.excursions = data);
  }

  getAllClients(){
    this.clientService.getAllClients().subscribe(data => this.clients = data);
  }

  save()
  {
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
    this.dialogRef.close();
  }
}