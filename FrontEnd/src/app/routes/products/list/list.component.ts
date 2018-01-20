import { Component, OnInit } from "@angular/core";
import { ProductsService } from "app/routes/products/services/products.service";
import { NzMessageService, NzModalService } from "ng-zorro-antd";
import { EditComponent } from "app/routes/products/edit/edit.component";

@Component({
    selector: "app-list",
    templateUrl: "./list.component.html",
    styles: []
})
export class ListComponent implements OnInit {
    _pageIndex = 1;
    _pageSize = 20;
    _total = 1;
    _dataset = [];
    _loading = true;
    _sortValue = null;

    _expandForm = false;

    _query: any ={
        name: ''
    };

    constructor(
        private productsService: ProductsService,
        private msg: NzMessageService,
        private modal: NzModalService
    ) {}

    ngOnInit() {
        this._refreshData();
    }

    _refreshData(reset = false) {
        if (reset) {
            this._pageIndex = 1;
        }
        this._loading = true;
        this.productsService
            .getProducts(this._pageIndex, this._pageSize, "", "", this._query)
            .subscribe((data: any) => {
                this._loading = false;
                this._total = data.info.total;
                this._dataset = data.results;
            });
    }

    _checkAll() {}

    _refreshStatus() {}

    _add() {
        var subscription = this.modal.open({
            title: "新增",
            content: EditComponent,
            footer: false,
            componentParams: {
                id: 0
            }
        });
        subscription.subscribe(result => {
            this._refreshData();
        });
    }

    _edit(item) {
        var subscription = this.modal.open({
            title: "编辑",
            content: EditComponent,
            footer: false,
            onOk() {
              //this.refreshData();
            },
            onCancel() {},
            componentParams: {
                id: item.id
            }
        });
        subscription.subscribe(result => {
            this._refreshData();
        });
    }

    _del(item) {
        this.productsService.delete(item.id).subscribe(res => {
            this.msg.success("操作成功");
            this._refreshData();
        });
    }
}
