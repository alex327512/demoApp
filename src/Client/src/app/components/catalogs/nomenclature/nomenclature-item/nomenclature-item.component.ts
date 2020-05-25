import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  Inject,
} from '@angular/core';
// import {
//   NomenclatureListDataSource,
//   NomenclatureListItem,
// } from '../nomenclature-list/nomenclature-list-datasource';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CatalogService } from '../../../../services/catalog.service';
import { NomenclatureListItem } from '../../../../interfaces/catalogs';
// import { NomenclatureListComponent } from '../nomenclature-list/nomenclature-list.component';

@Component({
  selector: 'app-warehouse-item',
  templateUrl: './nomenclature-item.component.html',
  styleUrls: ['./nomenclature-item.component.scss'],
})
export class NomenclatureItemComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<NomenclatureItemComponent>,
    private service: CatalogService,
    // private nomenclatureData: NomenclatureListComponent,
    // public nomenclatureData: NomenclatureListDataSource,
    @Inject(MAT_DIALOG_DATA) public data: NomenclatureListItem
  ) {}

  ngOnInit(): void {}

  // onAdd() {
  //   this.onAddWarehouse.emit({
  //     id: null,
  //     number: this.number,
  //     name: this.warehouseName.nativeElement.value,
  //   });
  //   this.dialogRef.close();
  // }
  onClose() {
    // this.service.form.reset();
    // this.service.initializeFormGroup();
    this.dialogRef.close();
  }
}
