import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncomingListLineComponent } from './incoming-list-line.component';

describe('IncomingListLineComponent', () => {
  let component: IncomingListLineComponent;
  let fixture: ComponentFixture<IncomingListLineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncomingListLineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncomingListLineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
