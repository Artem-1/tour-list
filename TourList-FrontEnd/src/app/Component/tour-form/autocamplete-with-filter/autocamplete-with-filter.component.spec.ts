import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AutocampleteWithFilterComponent } from './autocamplete-with-filter.component';

describe('AutocampleteWithFilterComponent', () => {
  let component: AutocampleteWithFilterComponent;
  let fixture: ComponentFixture<AutocampleteWithFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AutocampleteWithFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AutocampleteWithFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
