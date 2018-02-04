import { Component, OnInit } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd'
import { SimpleTableColumn } from '@delon/abc';
import { ProductsService } from 'app/routes/products/services/products.service';
import { SimpleTableComponent } from '../../../../../node_modules/_@delon_abc@0.6.5@@delon/abc/simple-table/simple-table.component';
import { EditComponent } from 'app/routes/products/edit/edit.component';

@Component({
  selector: 'app-simple-list',
  templateUrl: './simple-list.component.html',
  styles: []
})
export class SimpleListComponent implements OnInit {
  url: string = "Products";
  total: number;
  products: any[] = [];
  params = {
    name: ''
  };
  columns: SimpleTableColumn[] = [
    { title: '产品名称', index: 'name' },
    { title: '价格', index: 'price', type: "currency" },
    { title: '类别', index: 'typeProductName', },
    {
      title: '描述', index: 'description', format: (cell: any, row: any) => {
        return `<i class="">${cell.description}</i>`;
      }
    },
    {
      title: '操作',
      buttons: [
        { text: '编辑', type: 'modal', component: EditComponent, params: (record: any) => ({ id: record.id }) },
        {
          text: '删除', type: 'del', click: (record: any, instance: any) => {
            this.productsService.delete(record.id).subscribe(res => {
              this.msg.success("操作成功，请重新加载数据");
              console.log(instance);
              //instance.load();
            });
          }
        }
      ]
    }
  ];
  query = {
    name: ''
  }

  constructor(private msg: NzMessageService, private productsService: ProductsService) { }

  ngOnInit() {

  }

  change(ret: any) {

  }
}
