import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumptionItemComponent } from './consumption-item.component';

describe('ConsumptionItemComponent', () => {
  let component: ConsumptionItemComponent;
  let fixture: ComponentFixture<ConsumptionItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumptionItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumptionItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
