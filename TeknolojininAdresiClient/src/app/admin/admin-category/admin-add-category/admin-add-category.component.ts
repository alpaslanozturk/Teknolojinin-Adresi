import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoriesService } from 'src/_services/categories.service';

@Component({
  selector: 'app-admin-add-category',
  templateUrl: './admin-add-category.component.html',
  styleUrls: ['./admin-add-category.component.css']
})
export class AdminAddCategoryComponent implements OnInit {

  categoryForm: FormGroup;
  public response: {dbPath: ''};
  public uploadFinished = (event) => {
    this.response = event;
  }

  constructor(private formBuild: FormBuilder, private route: Router,
              private serviceCat: CategoriesService) { }

  ngOnInit() {
    this.createCategoryForm();
  }

  createCategoryForm() {
    this.categoryForm = this.formBuild.group({
      categoryId: [''],
      categoryName: ['', Validators.required],
      description: ['', Validators.required],
      pictureUrl: ['']
    });
  }
  addCategory() {
    this.categoryForm.controls['pictureUrl'].setValue(this.response.dbPath);
    console.log(this.categoryForm.value);
    this.serviceCat.addCategory(this.categoryForm.value).subscribe(data => {  } ,
      err => {console.log(err); } );
    this.route.navigate(['adminCategory']);
  }

}
