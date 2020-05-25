import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
// import { NomenclatureListDataSource } from './nomenclature-list-datasource';
import { NomenclatureListItem } from '../../../../interfaces/catalogs';

import { NomenclatureItemComponent } from '../nomenclature-item/nomenclature-item.component';
import { CatalogService } from '../../../../services/catalog.service';
import { log } from 'util';

// TODO: replace this with real data from your application

@Component({
  selector: 'app-warehouse-list',
  templateUrl: './nomenclature-list.component.html',
  styleUrls: ['./nomenclature-list.component.scss'],
})
export class NomenclatureListComponent extends MatTableDataSource<any>
  implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<NomenclatureListItem>;
  // dataSource: WarehouseListDataSource;
  searchKey: string;
  dataSource;
  index;

  name: string;
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name', 'actions'];
  constructor(
    public dialog: MatDialog,
    private service: CatalogService // public dataArray: NomenclatureListDataSource
  ) {
    super();
  }
  ngOnInit() {
    this.dataSource = new MatTableDataSource(
      this.service.getNomenclatureList()
    );
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
    console.log(this.dataSource);
  }

  onCreate() {
    // const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = false;
    // dialogConfig.autoFocus = true;
    // dialogConfig.width = '400px';
    const dialogRef = this.dialog.open(NomenclatureItemComponent, {
      width: '400px',
      data: { name: this.name, number: this.dataSource.data.length + 1 },
    });
    dialogRef.afterClosed().subscribe((result) => {
      // console.log(result);
      this.dataSource.data.push(result);
      this.refreshTable();
    });
  }

  public refreshTable() {
    this.dataSource.paginator = this.paginator;
  }

  onDelete(row) {
    console.log(row);

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
    const dialogRef = this.dialog.open(NomenclatureItemComponent, {
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
