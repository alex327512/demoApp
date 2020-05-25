import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncomingItemLineComponent } from './incoming-item-line.component';

describe('IncomingItemLineComponent', () => {
  let component: IncomingItemLineComponent;
  let fixture: ComponentFixture<IncomingItemLineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncomingItemLineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncomingItemLineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
