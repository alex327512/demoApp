import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Incoming } from '../interfaces/incoming';

@Injectable({
  providedIn: 'root',
})
export class IncomingDataService {
  ID = Guid.create();
  nomenclature = '';
  price = '';
  quantity = '';
  date = new Date();
  // Sum = +Price*+Quantity;
  incoming: Incoming;
  incomings: Incoming[] = [
    {
      ID: Guid.create(),
      nomenclature: 'AMD',
      quantity: 10,
      price: 50,
      // Sum: 500,
      // Warhouse: 'main',
      date: new Date(),
    },
    {
      ID: Guid.create(),
      nomenclature: 'INTEL',
      quantity: 1,
      price: 50,
      // Sum: 50,
      // Warhouse: 'main',
      date: new Date(),
    },
    {
      ID: Guid.create(),
      nomenclature: 'NVIDIA',
      quantity: 5,
      price: 50,
      // Sum: 250,
      // Warhouse: 'main',
      date: new Date(),
    },
  ];
  constructor() {}

  addIncoming() {
    this.incomings.push({
      ID: this.ID,
      nomenclature: this.nomenclature,
      price: +this.price,
      quantity: +this.quantity,
      // Sum: 250,
      // Warhouse: 'main',
      date: new Date(),
    });
    this.nomenclature = '';
    this.price = '';
    this.quantity = '';
  }
}
