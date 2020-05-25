import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { IncomingListComponent } from './components/documents/incoming/incoming-list/incoming-list.component';
import { ConsumptionComponent } from './documents/consumption/consumption.component';
import { NomenclatureListComponent } from './components/catalogs/nomenclature/nomenclature-list/nomenclature-list.component';
import { WarehouseListComponent } from './components/catalogs/warehouse/warehouse-list/warehouse-list.component';
import { IncomingItemComponent } from './components/documents/incoming/incoming-item/incoming-item.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'incoming', component: IncomingListComponent },
  { path: 'consumption', component: ConsumptionComponent },
  { path: 'nomenclature', component: NomenclatureListComponent },
  { path: 'warehouse', component: WarehouseListComponent },
  { path: 'incoming/:number', component: IncomingItemComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
