import { Component, Inject, OnInit } from '@angular/core';
import { TourService } from '../../Service/Tour/tour.service';
import { ExcursionService } from '../../Service/Excursion/excursion.service';
import { ClientService } from '../../Service/Client/client.service';
import { Tour } from '../../Model/tour';
import { Excursion } from '../../Model/excursion';
import { Client } from '../../Model/client';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

export interface DialogData {
  tour: Tour;
  mode: boolean;
}

@Component({
  selector: 'app-tour-form',
  templateUrl: './tour-form.component.html',
  styleUrls: ['./tour-form.component.css'],
  providers: [TourService]
})
export class TourFormComponent implements OnInit {

  tour: Tour;
  formMode: boolean = false;
  nameLabelExcursion: string = "Excursion:";
  nameLabelClient: string = "Client:";
  excursions: Excursion[];
  clients: Client[];

  constructor(
    private tourService: TourService,
    private excursionService: ExcursionService,
    private clientService: ClientService,
    public dialogRef: MatDialogRef<TourFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  ngOnInit(){
    this.tour = this.data.tour;
    this.formMode = this.data.mode;
    this.getAllExcursions();
    this.getAllClients();
  }

  onChangeExcursion($event){
    this.tour.excursion = $event;
  }

  onChangeClient($event){
    this.tour.client = $event;
  }

  getAllExcursions(){
    this.excursionService.getAllExcursions().subscribe(data => this.excursions = data);
  }

  getAllClients(){
    this.clientService.getAllClients().subscribe(data => this.clients = data);
    this.clientService.createClient("gu");
  }

  save()
  {
    if(this.formMode === true)
      this.tourService.createTour(this.tour);
    else
      this.tourService.updateTour(this.tour);
  }

  cancel() {
    this.dialogRef.close();
  }
}