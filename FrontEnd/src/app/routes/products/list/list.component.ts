import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'app/routes/products/services/products.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styles: []
})
export class ListComponent implements OnInit {

  _pageIndex = 1;
  _pageSize = 20;
  _dataset = [];
  _total = 1;
  constructor(private productsService: ProductsService) { }

  ngOnInit() {
    this.productsService.getProducts(1, 20, '' , '').subscribe((data: any) => {
      this._dataset = data.results;
    });
  }

  _dataChange() {

  }

  _pageIndexChange(){}

  _pageSizeChange(){}

  _checkAll() {}

  _refreshStatus() {}

  edit() {}

  active() {}

  del() {}
}
