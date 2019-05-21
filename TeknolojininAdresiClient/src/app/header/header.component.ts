import { Component, OnInit } from '@angular/core';
import { CategoriesService } from 'src/_services/categories.service';
import { IcategoriesListHome } from 'src/_models/icategoriesListHome';
import { AuthService } from 'src/_services/auth.service';
import { Iuser } from 'src/_models/iuser';
import { CartService } from 'src/_services/cart.service';
import { Icart } from 'src/_models/icart';
import { IproductsTopSelling } from 'src/_models/iproductsTopSelling';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/_services/alertify.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

cList: IcategoriesListHome[];
searchText: string;
currentUser: Iuser;
check: boolean;
catSelected: number;
cartLineList: Icart[] = [];
totalPrice: number;
cartsId: number;
loginForm: FormGroup;
currentUserName: string;

  constructor(private serviceCat: CategoriesService, private serviceAuth: AuthService,
              private serviceCart: CartService, private formBuilder: FormBuilder,
              private router: Router ) { }

  ngOnInit(): void {
    this.getCategoriesListHome();
    this.createLoginForm();
  }

  getCategoriesListHome() {
    this.serviceCat.getCategoriesListHome().subscribe( (data: IcategoriesListHome[] ) => {
    this.cList = data;  } );
  }

  logout() {  
    this.serviceAuth.logout();
  }

  getMainCart() {
    this.totalPrice = 0;
    const userId = parseInt( localStorage.getItem('userId') );
    this.serviceCart.getMainCart(userId).subscribe( (data: Icart[] ) => {
      this.cartLineList = data; data.forEach(element => {
        this.totalPrice += (element.unitPrice * element.quantity);
        this.cartsId = element.cartsId;
        });
      }
    );
  }

  removeToCart(productId: number) {
    const userId = parseInt( localStorage.getItem('userId') );
    this.serviceCart.removeToCart(userId, productId).subscribe(data => {
    });
    this.getMainCart();
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group(
      {
        userName: ['', Validators.required],
        password: ['', Validators.required]
      },
    );
  }

  login() {
    if (this.loginForm.valid) {
      this.serviceAuth.login(this.loginForm.value);
    } 
  }

  get isAuthenticated() {
    this.currentUserName = this.serviceAuth.getUser();
    return this.serviceAuth.isLogin();
  }

  get isAdmin() {
    return this.serviceAuth.isAdmin();
  }

  onCategorySelected(val: any) {
    this.catSelected = val;
  }

}
