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
  _total = 1;
  _dataset = [];
  _loading = true;
  _sortValue = null;
  
  constructor(private productsService: ProductsService) { }

  ngOnInit() {
    this.refreshData();
  }

  refreshData(reset = false) {
    if(reset){
      this._pageIndex = 1;
    }
    console.log(this._pageIndex);
    this._loading = true;
    this.productsService.getProducts(this._pageIndex, this._pageSize, '' , '').subscribe((data: any) => {
      this._loading = false;
      this._total = data.info.total;
      this._dataset = data.results;
    });
  }

  _checkAll() {}

  _refreshStatus() {}

  edit() {}

  active() {}

  del() {}
}
