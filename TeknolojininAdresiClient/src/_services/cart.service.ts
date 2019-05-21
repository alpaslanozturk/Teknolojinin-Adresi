import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IproductsTopSelling } from 'src/_models/iproductsTopSelling';
import { Icart } from 'src/_models/icart';
import { Observable } from 'rxjs';
import { Iorder } from 'src/_models/iorder';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  path = 'http://localhost:1228/api';

constructor(private http: HttpClient) { }

addToCart(userId: number, quantity: number, product: IproductsTopSelling) {
  return this.http.post<any>(this.path + '/carts/addToCart?userId=' + userId + '&' + 'quantity=' + quantity + '&' , product);
}

removeToCart(userId: number, productId: number) {
  return this.http.get<any>(this.path + '/carts/removeToCart?userId=' + userId + '&' + 'productId=' + productId);
}

getMainCart(userId: number): Observable<Icart[]> {
  return this.http.get<Icart[]>(this.path + '/carts/getMainCart?userId=' + userId);
}

checkout(userId: number, cartsId: number, order: Iorder) {
  return this.http.post<Iorder>(this.path + '/orders/completeOrder?userId=' + userId + '&' + 'cartsId=' + cartsId + '&' , order);
}
}
