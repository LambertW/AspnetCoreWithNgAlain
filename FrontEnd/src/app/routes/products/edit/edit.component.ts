import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ProductsService } from "app/routes/products/services/products.service";
import { TypeProductsService } from "app/routes/products/services/type-products.service";
import { NzModalSubject } from 'ng-zorro-antd';

@Component({
  selector: "app-edit",
  templateUrl: "./edit.component.html",
  styles: []
})
export class EditComponent implements OnInit {
  id: String;

  form: FormGroup;

  typeProducts: any;

  constructor(private fb: FormBuilder,
    private productsService: ProductsService,
    private typeProductsService: TypeProductsService,
    private subject: NzModalSubject) { }

  ngOnInit() {
    this.form = this.fb.group({
      id: [0],
      name: [null, [Validators.required]],
      price: [null, [Validators.required]],
      description: [null, []],
      //typeProductName: [null, []],
      typeProductId: [null, []]
    });

    this.initForm(this.id);
  }

  initForm(id) {
    this.typeProducts = this.typeProductsService.getTypeProducts();

    if (id <= 0)
      return;

    this.productsService.getProduct(id).subscribe(res => {
      this.form.setValue({
        id: res.id,
        name: res.name,
        description: res.description,
        price: res.price,
        //typeProductName: res.typeProductName,
        typeProductId: res.typeProductId
      });
    });
  }

  _submitForm($event, formValue) {
    //console.log($event);

    if (formValue.id > 0) {
      this.productsService.putProduct(formValue).subscribe();
    }
    else {
      this.productsService.postProduct(formValue).subscribe();
    }

    //console.log(formValue);

    this.subject.destroy();
  }

  _close() {
    this.subject.destroy();
  }
}
