import { Injectable } from "@angular/core";
import { _HttpClient } from "@delon/theme";
import { CacheService } from '@delon/cache';

@Injectable()
export class TypeProductsService {
    typeProducts = [];

    constructor(private http: _HttpClient,
        private cacheService: CacheService) {}

    getTypeProducts() {
        var url = "TypeProducts";

        return this.cacheService.get(`${url}`);
    }
}
