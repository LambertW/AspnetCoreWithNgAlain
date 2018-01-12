import { Injectable } from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { HttpParams } from '@angular/common/http';


@Injectable()
export class ProductsService {

    constructor(private http: _HttpClient){
        
    }

    getProducts(pageIndex = 1, pageSize = 10, sortField, sortOrder){
        var url = 'Products';

        return this.http.get(url, {
            page: `${pageIndex}`,
            results: `${pageSize}`,
            sortField: sortField,
            sortOrder: sortOrder
        });
    }
}