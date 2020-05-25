import { Injectable } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Guid } from 'guid-typescript';
import {
  NomenclatureListItem,
  WarehouseListItem,
} from '../interfaces/catalogs';

@Injectable()
export class CatalogService {
  constructor() {}

  form: FormGroup = new FormGroup({
    $key: new FormControl(Guid),
    number: new FormControl(null),
    warehouse: new FormControl('', Validators.required),
  });

  initializeFormGroup() {
    this.form.setValue({
      $key: null,
      number: null,
      warehouse: '',
    });
  }
  getNomenclatureList() {
    return NOMENCLATURE;
  }
  getWarehouseList() {
    return WAREHOUSES;
  }
}

const NOMENCLATURE: NomenclatureListItem[] = [
  { number: 1, name: 'AMD' },
  { number: 2, name: 'INTEL' },
  { number: 3, name: 'NVIDIA' },
  { number: 4, name: 'KINGSTON' },
  { number: 5, name: 'CORSAIR' },
  { number: 6, name: 'WD' },
  { number: 7, name: 'SEAGATE' },
  { number: 8, name: 'SAMSUNG' },
  { number: 9, name: 'PHILIPS' },
];

const WAREHOUSES: WarehouseListItem[] = [
  { number: 1, name: 'Hydrogen' },
  { number: 2, name: 'Helium' },
  { number: 3, name: 'Lithium' },
  { number: 4, name: 'Beryllium' },
  { number: 5, name: 'Boron' },
  { number: 6, name: 'Carbon' },
  { number: 7, name: 'Nitrogen' },
  { number: 8, name: 'Oxygen' },
];
