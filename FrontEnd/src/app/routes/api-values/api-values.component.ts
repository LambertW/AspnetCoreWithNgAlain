import { Component } from "@angular/core";
import { _HttpClient } from "@delon/theme";

@Component({
    selector: "app-api-values",
    templateUrl: "./api-values.component.html"
})
export class ApiValuesComponent {
    text: string;
    constructor(private http: _HttpClient) {
        http.get("/values").subscribe(response => {
            this.text = response as string;
        });
    }
}
