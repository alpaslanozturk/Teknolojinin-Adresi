import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private serviceAuth: AuthService) { }

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group(
      {
        userName: ['', Validators.required],
        password: ['', [Validators.required,
        Validators.minLength(4),
        Validators.maxLength(30)]],
        confirmPassword: ['', Validators.required]
      },
      {validator: this.passwordMatchValidator}
    );
  }

   passwordMatchValidator(g: FormGroup) {
     return g.get('password').value ===
     g.get('confirmPassword').value ? null : {mismatch: true };
   }
   register() {
    if (this.registerForm.valid) {
      this.serviceAuth.register(this.registerForm.value);
    }
  }


}
