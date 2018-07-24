import { Input, Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl } from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';
import { IOption } from './IOption';

@Component({
  selector: 'app-autocamplete-with-filter',
  templateUrl: './autocamplete-with-filter.component.html',
  styleUrls: ['./autocamplete-with-filter.component.css']
})
export class AutocampleteWithFilterComponent implements OnInit {

  myControl = new FormControl();
  @Output() valueChange = new EventEmitter<string>();
  @Input() selectedValue: IOption;
  @Input() options: IOption[];
  filteredOptions: Observable<IOption[]>;

  constructor() { }

  ngOnInit() {
    this.myControl.setValue(this.selectedValue);
    this.filteredOptions = this.myControl.valueChanges
      .pipe(
        startWith<string | IOption>(''),
        map(value => typeof value === 'string' ? value : value.name),
        map(name => name ? this._filter(name) : this.options)
      );
  }
  
  changed(model: string){
      this.valueChange.emit(model);
  }

  private _filter(name: string) : IOption[] {
    const filterValue = name.toLowerCase();
    return this.options.filter(option => option.name.toLowerCase().indexOf(filterValue) === 0);
  }

  displayFn(excursion?: IOption): string | undefined {
    return excursion ? excursion.name : undefined;
  }
}
