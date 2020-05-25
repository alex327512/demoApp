import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  Inject,
} from '@angular/core';
// import {
//   WarehouseListDataSource,
//   WarehouseListItem,
// } from '../warehouse-list/warehouse-list-datasource';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CatalogService } from '../../../../services/catalog.service';
import { WarehouseListItem } from '../../../../interfaces/catalogs';

@Component({
  selector: 'app-warehouse-item',
  templateUrl: './warehouse-item.component.html',
  styleUrls: ['./warehouse-item.component.scss'],
})
export class WarehouseItemComponent implements OnInit {
  @ViewChild('warehouseName') warehouseName: ElementRef;
  number = this.service.getWarehouseList().length + 1;

  constructor(
    public dialogRef: MatDialogRef<WarehouseItemComponent>,
    private service: CatalogService,
    @Inject(MAT_DIALOG_DATA) public data: WarehouseListItem
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
