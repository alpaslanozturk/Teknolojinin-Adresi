import { Component, OnInit, Input } from '@angular/core';
import { IaddCategory } from 'src/_models/iaddCategory';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CategoriesService } from 'src/_services/categories.service';

@Component({
  selector: 'app-admin-category-detail',
  templateUrl: './admin-category-detail.component.html',
  styleUrls: ['./admin-category-detail.component.css']
})
export class AdminCategoryDetailComponent implements OnInit {

  @Input() currentCategory: IaddCategory;
  categoryForm: FormGroup;
  category: IaddCategory;
  public response: {dbPath: ''};
  public uploadFinished = (event) => {
    this.response = event;
  }

  constructor(private formBuild: FormBuilder, private serviceCat: CategoriesService) { }

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

  updateCategory() {
    this.categoryForm.controls['pictureUrl'].setValue(this.response.dbPath);
    this.serviceCat.updateCategory(this.categoryForm.value)
    .subscribe(data => {  } ,
      err => {console.log(err); } );
  }

}
