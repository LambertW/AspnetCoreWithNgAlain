import { NgModule } from '@angular/core';

import { ProductsRoutingModule } from './products-routing.module';
import { ListComponent } from './list/list.component';
import { SharedModule } from '@shared/shared.module';
import { ProductsService } from 'app/routes/products/services/products.service';
import { EditComponent } from './edit/edit.component';
import { TypeProductsService } from 'app/routes/products/services/type-products.service';
import { SimpleListComponent } from './simple-list/simple-list.component';

@NgModule({
  imports: [
    SharedModule,
    ProductsRoutingModule
  ],
  declarations: [ListComponent, EditComponent, SimpleListComponent],
  providers: [
    ProductsService,
    TypeProductsService
  ],
  entryComponents: [
    ListComponent,
    EditComponent
  ]
})
export class ProductsModule { }
