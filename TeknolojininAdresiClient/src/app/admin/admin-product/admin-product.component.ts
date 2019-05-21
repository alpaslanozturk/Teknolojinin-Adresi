import { Component, OnInit, OnDestroy } from '@angular/core';
import { IproductsTopSelling } from 'src/_models/iproductsTopSelling';
import { ProductsService } from 'src/_services/products.service';
import { IproductList } from 'src/_models/iproductList';
import { Router } from '@angular/router';
import { Subscription, Subject } from 'rxjs';
import { filter, startWith, takeUntil } from 'rxjs/operators';
import { AlertifyService } from 'src/_services/alertify.service';

@Component({
  selector: 'app-admin-product',
  templateUrl: './admin-product.component.html',
  styleUrls: ['./admin-product.component.css']
})
export class AdminProductComponent implements OnInit {

  check: boolean;
  pList: IproductList[] = [];
  pageCount: number;
  currentProduct: IproductList;

  constructor(private servicePro: ProductsService, private route: Router,
              private alertify: AlertifyService) { }

  ngOnInit() : void {
    this.check = false;
    this.getProductsList();
  }

// get proList() {
//   // let list: IproductList[] = [];
//   this.servicePro.getProductListAdmin().subscribe(data => {
//     // list = data;
//     console.log(data);
//     return data;
//   })
//   return;
// }

  getProductsList() {
    this.servicePro.getProductListAdmin().subscribe(data => {
     this.pList = data  } , err => (console.log(err)));
    window.scrollTo(0, 0);
  }


  updateProduct(product: IproductList) {
    this.currentProduct = product;
    this.check = true;
  }

  mouseLeft() {
    this.check = !this.check;
  }

  addProduct() {
   this.route.navigate(['addProduct']);
  }

  deleteProduct(productId: number) {
    this.servicePro.deleteProduct(productId).subscribe();
    this.pList = this.pList.filter(x=> x.productId != productId);
    this.alertify.warning('Silindi');
    
  }
}
