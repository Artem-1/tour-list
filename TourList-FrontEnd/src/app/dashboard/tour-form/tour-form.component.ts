import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { Validators, FormGroup, FormBuilder, AbstractControl, ValidatorFn, FormArray } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';

import { TourService } from '../shared/services/tour/tour.service';
import { ExcursionService } from '../shared/services/excursion/excursion.service';
import { ExcursionSightService } from '../shared/services/excursion-sight/excursion-sight.service';
import { ClientService } from '../shared/services/client/client.service';
import { Tour } from '../shared/models/tour';
import { ExcursionSight } from '../shared/models/excursion-sight';

@Component({
  selector: 'app-tour-form',
  templateUrl: './tour-form.component.html',
  styleUrls: ['./tour-form.component.css']
})
export class TourFormComponent implements OnInit {

  title: string;
  tour: Tour;
  tourFg: FormGroup;
  formMode = false;
  submitted = false;
  sightFg: FormGroup;

  filteredExcursions: Observable<string[]>;
  filteredClients: Observable<string[]>;
  filteredExcursionSights: Observable<string[]>;
  
  get f_date() {
    return this.tourFg.controls.date;
  }

  get f_excursion() {
    return this.tourFg.controls.excursionName;
  }

  get f_client() {
    return this.tourFg.controls.clientName;
  }

  get f_excursionSightsList() {
    return this.tourFg.controls.excursionSightsList;
  }

  get f_excursionSight() {
    return this.sightFg.controls.excursionSightName;
  }

  constructor(
    private tourService: TourService,
    private excursionService: ExcursionService,
    private excursionSightService: ExcursionSightService,
    private clientService: ClientService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<TourFormComponent>,
    public snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: Tour) {}

  ngOnInit() {
    if(this.data != null) {
      this.formMode = false;
      this.title = "Edit tour";
      this.tour = this.data;
    }
    else {
      this.formMode = true;
      this.title = "New tour";
      this.tour = {
        date: new Date,
        client: {name: ""},
        excursion: {name: "", excursionSights: []},
        snapshotSights: [] };
    }

    this.tourFg = this.formBuilder.group({
      date: [this.tour.date, Validators.required],
      excursionName: [this.tour.excursion.name, [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      clientName: [this.tour.client.name, [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],

      excursionSightsList: this.formBuilder.array([], [this.sightLenValidator()]),
    });

    this.tour.excursion.excursionSights.forEach(element => {
      this.addSightToList(element)
    });

    this.sightFg = this.formBuilder.group({
      excursionSightName: ['', [Validators.required, Validators.minLength(2)]]
    });

    this.LoadExcursions();
    this.LoadClients();
    this.LoadExcursionSights();
  }

  private getFilteredWithName(control: AbstractControl, options: string[]) {
    return control.valueChanges
      .pipe(
        startWith(''),
        map(name => this._filter(name, options))
      );
  }

  private _filter(name: string, options: string[]) {
    const filterValue = name.toLowerCase();
    return options.filter(option => option.toLowerCase().includes(filterValue));
  }

  private sightLenValidator(): ValidatorFn {
    return (sights: FormArray): { [key: string]: any } => {
      if(sights.length !== 0)
        return null;
      
      return { listLength: true };
    }
  }

  private addSightToList(item: ExcursionSight): void {
    (<FormArray>this.f_excursionSightsList).push(
      this.formBuilder.group({
        name: [item.name, []]
      })
    );
  }

  LoadExcursions() {
    this.excursionService.getAllExcursions()
      .subscribe(data => {
          this.filteredExcursions = 
            this.getFilteredWithName(this.f_excursion, data);
        });
  }

  LoadClients() {
    this.clientService.getAllClients()
      .subscribe(data => {
        this.filteredClients = 
          this.getFilteredWithName(this.f_client, data);
      });
  }

  LoadExcursionSights() {
    this.excursionSightService.getAllSights()
      .subscribe(data => {
        this.filteredExcursionSights =
          this.getFilteredWithName(this.f_excursionSight, data);
      });
  }

  onPushSight() {
    if(this.sightFg.invalid)
      return;

    this.addSightToList({ name: this.f_excursionSight.value });
    this.f_excursionSight.setValue('');
  }

  onRemoveSight(sight: ExcursionSight) {
    let index = this.f_excursionSightsList.value.indexOf(sight);
    (<FormArray>this.f_excursionSightsList).removeAt(index);
  }
  
  save() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.tourFg.invalid) {
      return;
    }

    var message: string;

    this.tour.date = this.f_date.value;
    this.tour.client = { name: this.f_client.value };
    this.tour.excursion = {
      name: this.f_excursion.value,
      excursionSights: this.f_excursionSightsList.value
    };

    if(this.formMode == true) {
        this.tourService.createTour(this.tour).subscribe();
      message = "New tour was added";
    }
    else {
      this.tourService.updateTour(this.tour).subscribe();
      message = "Tour was edited";
    }

    this.snackBar.open(message, '', { duration: 3000 });
    this.dialogRef.close();
  }

  cancel() {
    if(confirm("Are you sure that you want to close popap? Your changing will not be saved."))
      this.dialogRef.close();
  }
}