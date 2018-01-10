import { NgModule } from '@angular/core';

import { ProductsRoutingModule } from './products-routing.module';
import { ListComponent } from './list/list.component';
import { SharedModule } from '@shared/shared.module';
import { ProductsService } from 'app/routes/products/services/products.service';

@NgModule({
  imports: [
    SharedModule,
    ProductsRoutingModule
  ],
  declarations: [ListComponent],
  providers: [
    ProductsService
  ],
  entryComponents: [
    ListComponent
  ]
})
export class ProductsModule { }
