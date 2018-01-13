import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ProductsService } from "app/routes/products/services/products.service";

@Component({
    selector: "app-edit",
    templateUrl: "./edit.component.html",
    styles: []
})
export class EditComponent implements OnInit {
    id: String;

    form: FormGroup;

    constructor(private fb: FormBuilder,
      private productsService: ProductsService) {}

    ngOnInit() {
        this.form = this.fb.group({
            id: [null],
            name: [null, [Validators.required]],
            price: [null, [Validators.required]],
            description: [null, []],
            typeProductName: [null, []]
        });

        this.initForm(this.id);
    }

    initForm(id) {
      this.productsService.getProduct(id).subscribe(res => {
        this.form.setValue({
          id: res.id,
          name: res.name,
          description: res.description,
          price: res.price,
          typeProductName: ''
        });
      });
    }
    
    _submitForm() {}
}
