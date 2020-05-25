import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncomingListComponent } from './incoming-list.component';

describe('IncomingListComponent', () => {
  let component: IncomingListComponent;
  let fixture: ComponentFixture<IncomingListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [IncomingListComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncomingListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
