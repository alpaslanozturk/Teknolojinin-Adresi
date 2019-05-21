import { Component, OnInit } from '@angular/core';
import { CategoriesService } from 'src/_services/categories.service';
import { IcategoriesHome } from 'src/_models/icategoriesHome';
import { ProductsService } from 'src/_services/products.service';
import { IproductsTopSelling } from 'src/_models/iproductsTopSelling';
import { IcategoriesListHome } from 'src/_models/icategoriesListHome';
import { CartService } from 'src/_services/cart.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  cListHome: IcategoriesListHome[];
  cList: IcategoriesHome[];
  pTopList: IproductsTopSelling[];
  pNewList: IproductsTopSelling[];

  constructor(private serviceCategories: CategoriesService, private serviceProducts: ProductsService,
              private serviceCart: CartService) {
   }

  ngOnInit() {
    this.getCategoriesHome();
    this.getCategoriesListHome();
    this.getProductsTopSelling();
    this.getProductsNew();
  }

  getCategoriesHome() {
    this.serviceCategories.getCategoriesHome().subscribe((cat: IcategoriesHome[]) => {
          this.cList = cat; }, err => (console.log(err))  );
    }
  getProductsTopSellingById(categoryId: number) {
    this.serviceProducts.getProductsTopSellingByCatId(categoryId).subscribe((pro: IproductsTopSelling[]) => {
      this.pTopList = pro; }, err => (console.log(err))  );
  }
  getCategoriesListHome() {
    this.serviceCategories.getCategoriesListHome().subscribe((cat: IcategoriesListHome[]) => {
      this.cListHome = cat; }, err => (console.log(err))  );
  }

  getProductsTopSelling() {
    this.serviceProducts.getProductsTopSelling().subscribe((pro: IproductsTopSelling[]) => {
      this.pTopList = pro; }, err => (console.log(err))  );
  }
  arrayOne(n: number): any[] {
    n = Math.ceil(n);
    return new Array(n);
  }
        
  arrayOneEmpty(n: number): any[] {
    n = Math.floor(n);
    return new Array(n);
  }

  getProductsNew() {
    this.serviceProducts.getProductsNew().subscribe((pro: IproductsTopSelling[]) => {
    this.pNewList = pro; }, err => (console.log(err))  );
  }

  getProductsNewById(categoryId: number) {
    this.serviceProducts.getProductsNewById(categoryId).subscribe((pro: IproductsTopSelling[]) => {
    this.pNewList = pro; }, err => (console.log(err))  );
  }
  addCart(product: IproductsTopSelling) {
    const userId = parseInt( localStorage.getItem('userId') );
    this.serviceCart.addToCart(userId, 1, product).subscribe(data => {
    });
  }
}
