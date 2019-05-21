import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IcategoriesHome } from 'src/_models/icategoriesHome';
import { IcategoriesList } from 'src/_models/icategoriesList';
import { IcategoriesListHome } from 'src/_models/icategoriesListHome';
import { IaddCategory } from 'src/_models/iaddCategory';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  path = 'http://localhost:1228/api';

constructor(private http: HttpClient) { }

getCategoriesHome(): Observable<IcategoriesHome[]> {
  return this.http.get<IcategoriesHome[]>(this.path + '/home/categoryIndex' );
}
getCategoriesList(): Observable<IcategoriesList[]> {
  return this.http.get<IcategoriesList[]>(this.path + '/categories/categoriesList' );
}
getCategoriesListHome(): Observable<IcategoriesListHome[]> {
  return this.http.get<IcategoriesListHome[]>(this.path + '/home/categoriesListHome' );
}
getCategoryListAdmin() {
  return this.http.get<IaddCategory[]>(this.path + '/categories/categoriesListAdmin' );
}

addCategory(category: IaddCategory) {
  console.log(category);
  return this.http.post<IaddCategory>(this.path + '/categories/addCategory', category);
}

updateCategory(category: IaddCategory) {
  return this.http.post<IaddCategory>(this.path + '/categories/updateCategory', category);
}
deleteCategory(categoryId: number) {
  return this.http.delete<any>(this.path + '/categories/deleteCategory?categoryId=' + categoryId);
}

}
