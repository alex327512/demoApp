import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { DocumentService } from '../../../../services/document.service';
import { MatDialog } from '@angular/material/dialog';
import { IncomingItemLineComponent } from '../incoming-item-line/incoming-item-line.component';
import { CatalogService } from 'src/app/services/catalog.service';

@Component({
  selector: 'app-incoming-item',
  templateUrl: './incoming-item.component.html',
  styleUrls: ['./incoming-item.component.scss'],
})
export class IncomingItemComponent extends MatTableDataSource<any>
  implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<any>;
  incoming: any;
  dataSource;
  incomingItem;
  searchKey: string;
  nomenclature;
  newNomenclature = this.nomenclatureService.getNomenclatureList();
  quantity;
  price;
  displayedColumns = ['number', 'nomenclature', 'quantity', 'price', 'actions'];
  constructor(
    private route: ActivatedRoute,
    private documentService: DocumentService,
    public dialog: MatDialog,
    private nomenclatureService: CatalogService
  ) {
    super();
  }

  ngOnInit(): void {
    this.incomingItem = this.documentService.getIncomingItem(
      +this.route.snapshot.params['number']
    );
    this.dataSource = new MatTableDataSource(this.incomingItem.body);
    // console.log(this.dataSource);

    this.dataSource.filterPredicate = (data: any, filter: string) =>
      data.nomenclature.name.indexOf(filter) != -1;
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.table.dataSource = this.dataSource;
  }
  onSearchClear() {
    this.searchKey = '';
    this.applyFilter();
  }
  refreshTable() {
    this.dataSource.paginator = this.paginator;
  }
  applyFilter() {
    this.dataSource.filter = this.searchKey.trim().toLowerCase();
    // console.log(this.dataSource.data);
    // console.log(
    //   this.dataSource.data.filter(
    //     (item) => item.nomenclature.name == this.searchKey.trim().toUpperCase()
    //   )
    // );

    // this.dataSource.filter = this.dataSource.filter(
    //   (item) => item.nomenclature.name == this.searchKey.trim().toLowerCase()
    // );

    // this.dataSource.filter = this.searchKey.trim().toLowerCase();
    this.dataSource.filterredData = this.dataSource.data.find(
      (item) => item.nomenclature.name == this.searchKey
    );
  }
  onCreate() {
    const dialogRef = this.dialog.open(IncomingItemLineComponent, {
      width: '400px',
      data: {
        number: this.dataSource.data.length + 1,
        nomenclature: this.newNomenclature,
        quantity: this.quantity,
        price: this.price,
      },
    });
    dialogRef.afterClosed().subscribe((result) => {
      // console.log(result);
      // console.log(this.dataSource);
      // console.log(
      //   this.newNomenclature.filter(
      //     (item) => item.number == result.nomenclature - 1
      //   )
      // );
      this.dataSource.data.push({
        number: result.number,
        nomenclature: this.newNomenclature.find(
          (item) => item.name == result.nomenclature
        ),
        quantity: result.quantity,
        price: result.price,
      });
      this.refreshTable();
    });
  }
}
