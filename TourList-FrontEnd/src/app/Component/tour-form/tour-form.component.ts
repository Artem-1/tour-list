import { Component, OnInit } from '@angular/core';
import { TourService } from '../../Service/Tour/tour.service';
import { ExcursionService } from '../../Service/Excursion/excursion.service';
import { ClientService } from '../../Service/Client/client.service';
import { Tour } from '../../Model/tour';
import { Excursion } from '../../Model/excursion';
import { Client } from '../../Model/client';

@Component({
  selector: 'app-tour-form',
  templateUrl: './tour-form.component.html',
  styleUrls: ['./tour-form.component.css']
})
export class TourFormComponent implements OnInit {

  tour: Tour;
  
  constructor(
    private tourService: TourService, 
    private excursionService: ExcursionService, 
    private clientService: ClientService
  ) { }

  ngOnInit() {

  }

  getTour(id: string) {
    this.tourService.getTour(id).subscribe(t => this.tour = t);
  }
}
