import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Icomment } from 'src/_models/icomment';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {

  path = 'http://localhost:1228/api/comments';

constructor(private http: HttpClient) { }

addComment(comment: Icomment) {
  return this.http.post<Icomment>(this.path + '/addComment', comment );
}

getProductDetail(productId: number) {
  return this.http.get<Icomment[]>(this.path + '/commentsByProId?productId=' + productId);
}


}
