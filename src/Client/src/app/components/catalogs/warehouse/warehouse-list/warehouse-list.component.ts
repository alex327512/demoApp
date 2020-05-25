import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { WarehouseItemComponent } from '../warehouse-item/warehouse-item.component';
import { CatalogService } from '../../../../services/catalog.service';
import { WarehouseListItem } from '../../../../interfaces/catalogs';

@Component({
  selector: 'app-warehouse-list',
  templateUrl: './warehouse-list.component.html',
  styleUrls: ['./warehouse-list.component.scss'],
})
export class WarehouseListComponent
  extends MatTableDataSource<WarehouseListItem>
  implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<WarehouseListItem>;
  // dataSource: WarehouseListDataSource;
  searchKey: string;
  dataSource;
  index;
  name: string;
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name', 'actions'];
  constructor(public dialog: MatDialog, private service: CatalogService) {
    super();
  }
  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.service.getWarehouseList());
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.refreshTable();
    this.table.dataSource = this.dataSource;
  }
  onSearchClear() {
    this.searchKey = '';
    this.applyFilter();
  }
  applyFilter() {
    this.dataSource.filter = this.searchKey.trim().toLowerCase();
  }

  onCreate() {
    // const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = false;
    // dialogConfig.autoFocus = true;
    // dialogConfig.width = '400px';
    const dialogRef = this.dialog.open(WarehouseItemComponent, {
      width: '400px',
      data: { name: this.name, number: this.dataSource.data.length + 1 },
    });
    dialogRef.afterClosed().subscribe((result) => {
      this.dataSource.data.push(result);
      this.refreshTable();
    });
  }

  public refreshTable() {
    this.dataSource.paginator = this.paginator;
  }

  onDelete(row) {
    this.index = this.dataSource.data.indexOf(row);
    if (this.index > -1) {
      this.dataSource.data.splice(this.index, 1);
      for (let i = 0; i < this.dataSource.data.length; i++) {
        this.dataSource.data[i].number = i + 1;
      }
      this.index = null;
    }

    this.refreshTable();
  }

  onEdit(row) {
    const dialogRef = this.dialog.open(WarehouseItemComponent, {
      width: '400px',
      data: { name: row.name, number: row.number },
    });
    dialogRef.afterClosed().subscribe((result) => {
      this.index = this.dataSource.data.indexOf(row);
      if (this.index > -1) {
        if (result === undefined) {
          this.dataSource.data[this.index].name = row.name;
        } else {
          this.dataSource.data[this.index].name = result.name;
        }

        this.index = null;
      }
      this.refreshTable();
    });
  }
}
