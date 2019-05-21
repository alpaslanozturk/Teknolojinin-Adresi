import { Component, OnInit, Input } from '@angular/core';
import { IproductsTopSelling } from 'src/_models/iproductsTopSelling';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductsService } from 'src/_services/products.service';
import {FileUploader} from 'ng2-file-upload';
import { IpicturesProduct } from 'src/_models/ipicturesProduct';
import { IaddProduct } from 'src/_models/iaddProduct';
import { IproductList } from 'src/_models/iproductList';
import { IcategoriesListHome } from 'src/_models/icategoriesListHome';
import { CategoriesService } from 'src/_services/categories.service';
import { Router, NavigationEnd } from '@angular/router';
import { AlertifyService } from 'src/_services/alertify.service';

@Component({
  selector: 'app-admin-product-detail',
  templateUrl: './admin-product-detail.component.html',
  styleUrls: ['./admin-product-detail.component.css']
})
export class AdminProductDetailComponent implements OnInit {

  @Input() currentProduct: IproductList;
  productForm: FormGroup;
  catList: IcategoriesListHome[];
  catSelected: number;
  product: IproductsTopSelling;
  products: IaddProduct[] = [];
  currentMain: IpicturesProduct;
  public response: {dbPath: ''};
  public uploadFinished = (event) => {
    this.response = event;
  }



  constructor(private formBuild: FormBuilder, private serviceProduct: ProductsService,
              private serviceCat: CategoriesService, private router: Router,
              private alertify: AlertifyService) { }

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

  updateProduct() {
    this.productForm.controls['pictureUrl'].setValue(this.response.dbPath);
    console.log(this.productForm.value);
    this.serviceProduct.updateProduct(this.productForm.value)
    .subscribe(data => { 
      this.alertify.success('Güncelleme Başarılı');
     } ,
      err => {console.log(err); } );
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
