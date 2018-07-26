import { Component, OnInit } from '@angular/core';
import {Tour} from '../../Model/tour';
import { TourService } from '../../Service/Tour/tour.service';
import { MatDialog } from '@angular/material';
import { TourFormComponent } from '../tour-form/tour-form.component';

@Component({
  selector: 'app-tour-list',
  templateUrl: './tour-list.component.html',
  styleUrls: ['./tour-list.component.css']
})
export class TourListComponent implements OnInit {

  tours: Tour[];
  displayedColumns: string[] = ["date", "excursion", "client"];

  constructor(private tourService: TourService, public dialog: MatDialog) { }

  ngOnInit() {
    this.getTours();
  }

  getTours()
  {
    this.tourService.getAllTours().subscribe(tours => this.tours = tours);
  }

  openDialog(item: Tour): void {
    const dialogRef = this.dialog.open(TourFormComponent, {
      height: '500px',
      width: '500px',
      data: item
    });

    dialogRef.afterClosed().subscribe(() => {
      console.log('The dialog was closed');
      this.getTours();
    });
  }

  onCreate()
  {
    this.openDialog(null);
  }

  onEdit(item: Tour): void {
    this.openDialog(item);
  }
}
