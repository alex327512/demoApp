import { Component, OnInit, Inject } from '@angular/core';
import { CatalogService } from 'src/app/services/catalog.service';
import { DocumentService } from 'src/app/services/document.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-incoming-item-line',
  templateUrl: './incoming-item-line.component.html',
  styleUrls: ['./incoming-item-line.component.scss'],
})
export class IncomingItemLineComponent implements OnInit {
  nomenclatures = this.nomenclatureService.getNomenclatureList();
  // number = this.data.incomingItem.body.length + 1;
  // price;
  // quantity;
  // nomenclatureName;
  constructor(
    public dialogRef: MatDialogRef<IncomingItemLineComponent>,
    private nomenclatureService: CatalogService,
    private documentService: DocumentService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    // console.log(this.data);
  }
  onSave() {
    // this.data.incomingItem.body.push({
    //   number: this.number,
    //   nomenclature: this.nomenclatures.filter(
    //     (item) => item.name == this.nomenclatureName
    //   ),
    //   quantity: this.quantity,
    //   price: this.price,
    // });
    // this.dialogRef.close();
    // console.log(this.data.incomingItem.body);
  }
  onClose() {
    // this.service.form.reset();
    // this.service.initializeFormGroup();
    this.dialogRef.close();
  }
}
