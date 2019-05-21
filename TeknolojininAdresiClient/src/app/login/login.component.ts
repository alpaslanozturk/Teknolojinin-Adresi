import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/_services/auth.service';
import { Iuser } from 'src/_models/iuser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @Output() valueChange = new EventEmitter();
  loginForm: FormGroup;
  currentUser: Iuser;

  constructor(private formBuilder: FormBuilder, private serviceAuth: AuthService) { }

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
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

  // isUserLogin() {
  //   if (this.serviceAuth.isLogin()) {
  //     this.currentUser = this.serviceAuth.getUser();
  //     this.valueChange.emit(this.currentUser);
  //     return true;
  //   } else {
  //     return false;
  //   }
  // }
}
