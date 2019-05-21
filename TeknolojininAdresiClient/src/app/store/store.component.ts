import { Component, OnInit, Input } from '@angular/core';
import { CategoriesService } from 'src/_services/categories.service';
import { IcategoriesList } from 'src/_models/icategoriesList';
import { ProductsService } from 'src/_services/products.service';
import { IproductsTopSelling } from 'src/_models/iproductsTopSelling';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {

cList: IcategoriesList[];
pList: IproductsTopSelling[];
pageCount: number;
paramsHtmlCat: number;
paramsHtmlSearch: string;

  constructor(private serviceCat: CategoriesService, private servicePro: ProductsService,
              private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe( (params: Params ) => {
      window.scrollTo(0, 0);
      const paramsCat = params.categoryId;
      const paramsSearch = params.search;
      this.paramsHtmlCat = paramsCat;
      this.paramsHtmlSearch = paramsSearch;
      this.getCategoriesList();
      this.getProductsList(1, paramsSearch, paramsCat);
   });
  }

  getCategoriesList() {
    this.serviceCat.getCategoriesList().subscribe((data: IcategoriesList[]) => {
     this.cList = data; } , err => (console.log(err)));
  }

  getProductsList(page, paramsSearch, categoryId?) {
    this.servicePro.getProductsList(page, paramsSearch, categoryId).subscribe((data: any) => {
     this.pList = data.dto; this.pageCount = parseInt(data.pageCount); } , err => (console.log(err)));
    window.scrollTo(0, 0);
  }

  arrayOne(n: number): any[] {
    n = Math.ceil(n);
    return new Array(n);
  }
        
  arrayOneEmpty(n: number): any[] {
    n = Math.floor(n);
    return new Array(n);
  }
}
