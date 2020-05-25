import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Incoming } from '../interfaces/documents';
import { CatalogService } from './catalog.service';

@Injectable({
  providedIn: 'root',
})
export class DocumentService {
  ID = Guid.create();
  nomenclatureList = this.CatalogService.getNomenclatureList();
  price = '';
  quantity = '';
  date = new Date();
  // Sum = +Price*+Quantity;
  incoming: any;
  incomings: any[] = [
    {
      header: {
        id: Guid.create(),
        title: 'Incoming document',
        date: new Date(),
        number: 1,
      },
      body: [
        {
          number: 1,
          nomenclature: this.nomenclatureList[1],
          quantity: 10,
          price: 50,
        },
        {
          number: 2,
          nomenclature: this.nomenclatureList[2],
          quantity: 1,
          price: 50,
        },
        {
          number: 3,
          nomenclature: this.nomenclatureList[3],
          quantity: 5,
          price: 50,
        },
      ],
    },
    {
      header: {
        id: Guid.create(),
        title: 'Incoming document',
        date: new Date(),
        number: 2,
      },
      body: [
        {
          number: 1,
          nomenclature: this.nomenclatureList[4],
          quantity: 10,
          price: 50,
        },
        {
          number: 2,
          nomenclature: this.nomenclatureList[5],
          quantity: 1,
          price: 50,
        },
        {
          number: 3,
          nomenclature: this.nomenclatureList[6],
          quantity: 5,
          price: 50,
        },
      ],
    },
    {
      header: {
        id: Guid.create(),
        title: 'Incoming document',
        date: new Date(),
        number: 3,
      },
      body: [
        {
          number: 1,
          nomenclature: this.nomenclatureList[7],
          quantity: 10,
          price: 50,
        },
        {
          number: 2,
          nomenclature: this.nomenclatureList[8],
          quantity: 1,
          price: 50,
        },
        {
          number: 3,
          nomenclature: this.nomenclatureList[0],
          quantity: 5,
          price: 50,
        },
      ],
    },
  ];
  constructor(private CatalogService: CatalogService) {}
  getIncomingData() {
    return this.incomings;
  }
  getIncomingItem(number) {
    return this.incomings.find((incoming) => incoming.header.number === number);
  }
  // addIncoming() {
  //   this.incomings.push({
  //     ID: this.ID,
  //     nomenclature: this.nomenclature,
  //     price: +this.price,
  //     quantity: +this.quantity,
  //     // Sum: 250,
  //     // Warhouse: 'main',
  //     date: new Date(),
  //   });
  //   this.nomenclature = '';
  //   this.price = '';
  //   this.quantity = '';
  // }
}
