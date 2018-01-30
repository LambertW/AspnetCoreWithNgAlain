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
  url: string = "Products";
  total: number;
  products: any[] = [];
  params = {};
  columns: SimpleTableColumn[] = [
    { title: '产品名称', index: 'name' },
    { title: '价格', index: 'price' }
  ];
  query = {
    name: ''
  }

  constructor(private msg: NzMessageService, private productsService: ProductsService) { }

  ngOnInit() {
    // this.productsService.getProducts(1, 10, '', '', this.query)
    //   .subscribe((res: any) => {
    //     console.log(res);
    //     this.products = res.results;
    //     this.total = res.info.total;
    //   });
  }

  change(ret: any) {
    
  }
}
