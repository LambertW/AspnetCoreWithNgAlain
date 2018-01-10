import { Injectable } from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { HttpParams } from '@angular/common/http';


@Injectable()
export class ProductsService {

    constructor(private http: _HttpClient){
        
    }

    getProducts(pageIndex = 1, pageSize = 10, sortField, sortOrder){
        var url = 'Products';
        let params = new HttpParams()
            .append('page', `${pageIndex}`)
            .append('results', `${pageSize}`)
            .append('sortField', sortField)
            .append('sortOrder', sortOrder);

        return this.http.get(url);
    }
}