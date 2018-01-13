import { NgModule } from '@angular/core';

import { ProductsRoutingModule } from './products-routing.module';
import { ListComponent } from './list/list.component';
import { SharedModule } from '@shared/shared.module';
import { ProductsService } from 'app/routes/products/services/products.service';
import { EditComponent } from './edit/edit.component';

@NgModule({
  imports: [
    SharedModule,
    ProductsRoutingModule
  ],
  declarations: [ListComponent, EditComponent],
  providers: [
    ProductsService
  ],
  entryComponents: [
    ListComponent,
    EditComponent
  ]
})
export class ProductsModule { }
