import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { MaterialModule } from './material/material.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConsumptionComponent } from './documents/consumption/consumption.component';
import { HomeComponent } from './home/home.component';
import { IncomingItemComponent } from './components/documents/incoming/incoming-item/incoming-item.component';
import { IncomingListComponent } from './components/documents/incoming/incoming-list/incoming-list.component';
import { MainNavComponent } from './components/main-nav/main-nav.component';
import { NomenclatureListComponent } from './components/catalogs/nomenclature/nomenclature-list/nomenclature-list.component';
import { NomenclatureItemComponent } from './components/catalogs/nomenclature/nomenclature-item/nomenclature-item.component';
import { WarehouseListComponent } from './components/catalogs/warehouse/warehouse-list/warehouse-list.component';
import { WarehouseItemComponent } from './components/catalogs/warehouse/warehouse-item/warehouse-item.component';
// import { WarehouseListDataSource } from './components/catalogs/warehouse/warehouse-list/warehouse-list-datasource';
// import { NomenclatureListDataSource } from './components/catalogs/nomenclature/nomenclature-list/nomenclature-list-datasource';
import { ConsumptionListComponent } from './components/documents/consumption/consumption-list/consumption-list.component';
import { ConsumptionItemComponent } from './components/documents/consumption/consumption-item/consumption-item.component';
import { CatalogService } from './services/catalog.service';
import { IncomingItemLineComponent } from './components/documents/incoming/incoming-item-line/incoming-item-line.component';
import { IncomingListLineComponent } from './components/documents/incoming/incoming-list-line/incoming-list-line.component';

@NgModule({
  declarations: [
    AppComponent,
    ConsumptionComponent,
    HomeComponent,
    IncomingItemComponent,
    IncomingListComponent,
    MainNavComponent,
    NomenclatureListComponent,
    NomenclatureItemComponent,
    WarehouseListComponent,
    WarehouseItemComponent,
    ConsumptionListComponent,
    ConsumptionItemComponent,
    IncomingItemLineComponent,
    IncomingListLineComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    LayoutModule,
    MaterialModule,
  ],
  providers: [
    // WarehouseListDataSource,
    WarehouseListComponent,
    // NomenclatureListDataSource,
    CatalogService,
    NomenclatureListComponent,
  ],
  bootstrap: [AppComponent],
  entryComponents: [WarehouseItemComponent, NomenclatureItemComponent],
})
export class AppModule {}
