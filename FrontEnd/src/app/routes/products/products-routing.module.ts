import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from 'app/routes/products/list/list.component';
import { SimpleListComponent } from 'app/routes/products/simple-list/simple-list.component';

const routes: Routes = [
    { path: 'list', component: ListComponent },
    { path: 'simple-list', component: SimpleListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
