import { NgModule } from '@angular/core';

import { ProductsRoutingModule } from './products-routing.module';
import { ListComponent } from './list/list.component';
import { SharedModule } from '@shared/shared.module';

@NgModule({
  imports: [
    SharedModule,
    ProductsRoutingModule
  ],
  declarations: [ListComponent],
  entryComponents: [
    ListComponent
  ]
})
export class ProductsModule { }
