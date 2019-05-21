import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IproductsTopSelling } from 'src/_models/iproductsTopSelling';
import { IproductList } from 'src/_models/iproductList';
import { IaddProduct } from 'src/_models/iaddProduct';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  path = 'http://localhost:1228/api';

constructor(private http: HttpClient) { }


getProductsTopSellingStore(): Observable<IproductsTopSelling[]> {
  return this.http.get<IproductsTopSelling[]>(this.path + '/home/productTopSelling' );
}

getProductsTopSellingByCatId(categoryId: number): Observable<IproductsTopSelling[]> {
  return this.http.get<IproductsTopSelling[]>(this.path + '/home/productTopSelling?categoryId=' + categoryId );
}
getProductsTopSelling(): Observable<IproductsTopSelling[]> {
  return this.http.get<IproductsTopSelling[]>(this.path + '/home/productTopSelling' );
}

getProductsNew(): Observable<IproductsTopSelling[]> {
  return this.http.get<IproductsTopSelling[]>(this.path + '/home/productIndex' );
}

getProductsNewById(categoryId: number): Observable<IproductsTopSelling[]> {
  return this.http.get<IproductsTopSelling[]>(this.path + '/home/productIndex?categoryId=' + categoryId );
}

getProductsList(page: number, search: string, categoryId?: number) {
  if (search === undefined) {
    return this.http.get<any>(this.path + '/products/productList?page=' + page + '&' + 'categoryId=' + categoryId);
  } else {
    return this.http.get<any>(this.path + '/products/productList?page=' + page + '&' + 'categoryId=' + categoryId
    + '&' + 'search=' + search );
  }
}

getProductDetail(productId: number) {
  return this.http.get<IproductsTopSelling>(this.path + '/products/productDetail?productId=' + productId);
}

getProductListAdmin(): Observable<IproductList[]> {
  return this.http.get<IproductList[]>(this.path + '/products/productsListAdmin');
}

addProduct(product: IaddProduct) {
  return this.http.post<IaddProduct>(this.path + '/products/addProduct', product);
}

updateProduct(product: IaddProduct) {
  return this.http.post<IaddProduct>(this.path + '/products/updateProduct', product);
}

deleteProduct(productId: number) {
  let headers = new HttpHeaders();
  headers = headers.append('Content-Type', 'application/json; charset=UTF-8');
  return this.http.delete<any>(this.path + '/products/deleteProduct?productId=' + productId, { headers : headers });
}

}
