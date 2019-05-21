import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IpicturesProduct } from 'src/_models/ipicturesProduct';

@Injectable({
  providedIn: 'root'
})
export class PicturesService {

  path = 'http://localhost:1228/api/pictures';

constructor(private http: HttpClient) { }


getPicturesProduct(productId: number): Observable<IpicturesProduct[]> {
  return this.http.get<IpicturesProduct[]>(this.path + '/picturesProduct?productId=' + productId );
}
}
