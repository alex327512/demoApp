import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';

import { NomenclatureListComponent } from './nomenclature-list.component';

describe('NomenclatureListComponent', () => {
  let component: NomenclatureListComponent;
  let fixture: ComponentFixture<NomenclatureListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NomenclatureListComponent ],
      imports: [
        NoopAnimationsModule,
        MatPaginatorModule,
        MatSortModule,
        MatTableModule,
      ]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NomenclatureListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
