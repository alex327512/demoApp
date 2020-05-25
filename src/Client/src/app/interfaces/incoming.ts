import { Guid } from 'guid-typescript';

export interface Incoming {
  ID: Guid;
  nomenclature: string;
  quantity: number;
  price: number;
  // sum: number;
  // warhouse: string;
  date: Date;
}
