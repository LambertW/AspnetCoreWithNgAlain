import { Component, OnInit } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd'
import { SimpleTableColumn } from '@delon/abc';
import { ProductsService } from 'app/routes/products/services/products.service';

@Component({
  selector: 'app-simple-list',
  templateUrl: './simple-list.component.html',
  styles: []
})
export class SimpleListComponent implements OnInit {
  pi: number;
  ps: number;
  products: any[] = [];
  params = {};
  columns: SimpleTableColumn[] = [
    { title: '产品名称', index: 'name' }
  ];
  query = {
    name: ''
  }

  constructor(private msg: NzMessageService, private productsService: ProductsService) { }

  ngOnInit() {
    this.productsService.getProducts(this.pi, this.ps, '', '', this.query)
      .subscribe(res => this.products = res.results );
  }

}
