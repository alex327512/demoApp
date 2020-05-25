import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumptionListComponent } from './consumption-list.component';

describe('ConsumptionListComponent', () => {
  let component: ConsumptionListComponent;
  let fixture: ComponentFixture<ConsumptionListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumptionListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumptionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
