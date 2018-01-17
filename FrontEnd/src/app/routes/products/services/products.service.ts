import { Injectable } from "@angular/core";
import { _HttpClient } from "@delon/theme";

@Injectable()
export class ProductsService {
    constructor(private http: _HttpClient) {}

    getProducts(pageIndex = 1, pageSize = 10, sortField, sortOrder) {
        var url = "Products";

        return this.http.get(url, {
            page: `${pageIndex}`,
            results: `${pageSize}`,
            sortField: sortField,
            sortOrder: sortOrder
        });
    }

    delete(id: number) {
        var url = "Products";

        return this.http.delete(url, {
            id: `${id}`
        });
    }

    getProduct(id: number) {
        var url = "Products";

        return this.http.get(`${url}/${id}`);
    }

    postProduct(data: any) {
        var url = "Products";

        return this.http.post(`${url}`, data);
    }

    putProduct(data: any) {
        var url = "Products";

        return this.http.put(`${url}/${data.id}`, data);
    }
}
