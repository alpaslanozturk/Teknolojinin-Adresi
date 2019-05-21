import { Component, OnInit } from '@angular/core';
import { IaddCategory } from 'src/_models/iaddCategory';
import { CategoriesService } from 'src/_services/categories.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-category',
  templateUrl: './admin-category.component.html',
  styleUrls: ['./admin-category.component.css']
})
export class AdminCategoryComponent implements OnInit {

  check: boolean;
  cList: IaddCategory[];
  currentCategory: IaddCategory;

  constructor(private serviceCat: CategoriesService, private route: Router) { }

  ngOnInit() {
    this.check = false;
    this.getCategoryList();
  }

  getCategoryList() {
    this.serviceCat.getCategoryListAdmin().subscribe(data => {
     this.cList = data;  } , err => (console.log(err)));
    window.scrollTo(0, 0);
  }
  updateCategory(category: IaddCategory) {
    this.currentCategory = category;
    this.check = true;
  }

  mouseLeft() {
    this.check = !this.check;
  }

  addCategory() {
   this.route.navigate(['addCategory']);
  }

  deleteCategory(categoryId: number) {
    this.serviceCat.deleteCategory(categoryId).subscribe(data => {
    });
  }

}
