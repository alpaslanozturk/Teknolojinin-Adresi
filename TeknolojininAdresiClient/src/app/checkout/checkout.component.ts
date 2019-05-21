import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/_services/cart.service';
import { Iuser } from 'src/_models/iuser';
import { Icart } from 'src/_models/icart';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  currentUser: Iuser;
  cartLineList: Icart[] = [];
  totalPrice: number;
  cartsId: number;
  checkoutForm: FormGroup;

  constructor(private serviceCart: CartService, private formBuilder: FormBuilder,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.createCheckoutForm();
    this.getMainCart();
  }

  createCheckoutForm() {
    this.checkoutForm = this.formBuilder.group(
      {
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        email: ['', Validators.required],
        adress: ['', Validators.required],
        phoneNumber: ['', Validators.required],
      },
    );
  }

  getMainCart() {
    this.totalPrice = 0;
    const userId = parseInt( localStorage.getItem('userId') );
    this.serviceCart.getMainCart(userId).subscribe( (data: Icart[] ) => {
      this.cartLineList = data; data.forEach(element => {
      this.totalPrice += (element.unitPrice * element.quantity);
      this.cartsId = element.cartsId;
      }) ;
    } );
  }

  checkout() {
    const userId = parseInt( localStorage.getItem('userId') );
    console.log(userId);
    console.log(this.cartsId);
    console.log(this.checkoutForm.value);
    this.serviceCart.checkout(userId, this.cartsId, this.checkoutForm.value).subscribe(data => {
    });
  }

}
