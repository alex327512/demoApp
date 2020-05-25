import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { Guid } from 'guid-typescript';

import { DocumentService } from '../../../../services/document.service';
import { IncomingListLineComponent } from '../incoming-list-line/incoming-list-line.component';
import { CatalogService } from 'src/app/services/catalog.service';
// import { IncomingItemComponent } from '../incoming-item/incoming-item.component';

@Component({
  selector: 'app-incoming-list',
  templateUrl: './incoming-list.component.html',
  styleUrls: ['./incoming-list.component.scss'],
})
export class IncomingListComponent implements OnInit {
  incomingData: any;
  index: any;
  incoming: any;
  // number = this.incomingData.length + 1;
  date = new Date();
  id = Guid.create();
  title;
  constructor(
    private DocumentService: DocumentService,
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private CatalogService: CatalogService
  ) {}

  ngOnInit(): void {
    this.incomingData = this.DocumentService.getIncomingData();
    this.incoming = this.DocumentService.getIncomingItem(
      +this.route.snapshot.params['number']
    );
  }
  // onEdit(incomingItem) {
  //   const dialogRef = this.dialog.open(IncomingItemComponent, {
  //     width: '400px',
  //     data: incomingItem,
  //   });
  // dialogRef.afterClosed().subscribe((result) => {
  //   this.index = this.dataSource.data.indexOf(row);
  //   if (this.index > -1) {
  //     if (result === undefined) {
  //       this.dataSource.data[this.index].name = row.name;
  //     } else {
  //       this.dataSource.data[this.index].name = result.name;
  //     }

  //     this.index = null;
  //   }
  //   this.refreshTable();
  // });
  // }

  // onDelete(incomingItem) {
  //   this.index = this.incomingData.indexOf(incomingItem);
  //   console.log(this.index + '0');

  //   if (this.index > -1) {
  //     console.log(this.index + '1');
  //     this.incomingData.splice(this.index, 1);
  //     this.index = null;
  //   }
  //   console.log(this.incomingData);

  //   // this.refreshTable();
  // }
  addIncoming() {
    const dialogRef = this.dialog.open(IncomingListLineComponent, {
      width: '400px',
      data: {
        id: this.id,
        title: this.title,
        number: this.incomingData.length + 1,
        date: this.date,
      },
    });
    dialogRef.afterClosed().subscribe((result) => {
      this.incomingData.push({
        header: {
          id: result.id,
          title: result.title,
          number: result.number,
          date: result.date,
        },
        body: {},
      });
    });
    console.log(this.incomingData);
  }
}
