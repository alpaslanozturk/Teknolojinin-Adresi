import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductsService } from 'src/_services/products.service';
import { Router, NavigationEnd } from '@angular/router';
import { IcategoriesListHome } from 'src/_models/icategoriesListHome';
import { CategoriesService } from 'src/_services/categories.service';

@Component({
  selector: 'app-admin-add-product',
  templateUrl: './admin-add-product.component.html',
  styleUrls: ['./admin-add-product.component.css']
})
export class AdminAddProductComponent implements OnInit {

  catList: IcategoriesListHome[];
  catSelected: number;
  productForm: FormGroup;
  public response: {dbPath: ''};
  public uploadFinished = (event) => {
    this.response = event;
  }

  constructor(private formBuild: FormBuilder, private serviceProduct: ProductsService,
              private route: Router, private serviceCat: CategoriesService) { }

  ngOnInit() {
    this.createProductForm();
    this.getCategory();
  }

  createProductForm() {
    this.productForm = this.formBuild.group({
      productId: [''],
      productName: ['', Validators.required],
      unitPrice: ['', Validators.required],
      oldPrice: [''],
      unitsInStock: ['', Validators.required],
      sellCount: ['', Validators.required],
      pictureUrl: [''],
      categoriesId: ['', Validators.required]
    });
  }
  addProduct() {
    this.productForm.controls['pictureUrl'].setValue(this.response.dbPath);
    this.serviceProduct.addProduct(this.productForm.value)
    .subscribe(data => {  } ,
      err => {console.log(err); } );
    this.route.navigate(['adminProduct']);
  }

  onCategorySelected(val: any) {
    this.productForm.controls['categoriesId'].setValue(val);
  }

  getCategory() {
    this.serviceCat.getCategoriesListHome().subscribe(data => {
      this.catList = data;
    })
  }

}
