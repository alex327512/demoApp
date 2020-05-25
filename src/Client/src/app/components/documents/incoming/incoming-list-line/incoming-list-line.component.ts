import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DocumentService } from 'src/app/services/document.service';
import { CatalogService } from 'src/app/services/catalog.service';

@Component({
  selector: 'app-incoming-list-line',
  templateUrl: './incoming-list-line.component.html',
  styleUrls: ['./incoming-list-line.component.scss'],
})
export class IncomingListLineComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<IncomingListLineComponent>,
    private nomenclatureService: CatalogService,
    private documentService: DocumentService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {}
  onClose() {
    this.dialogRef.close();
  }
}
