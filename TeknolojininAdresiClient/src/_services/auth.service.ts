import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Iregister } from 'src/_models/iregister';
import { Ilogin } from 'src/_models/ilogin';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { Iuser } from 'src/_models/iuser';
import { AlertifyService } from './alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  path = 'http://localhost:1228/api/auth/';
  user: Iuser;

constructor(private http: HttpClient, private jwtHelper: JwtHelperService,
            private router: Router) { }

register(user: Iregister) {
  let headers = new HttpHeaders();
  headers = headers.append('Content-Type', 'application/json; charset=UTF-8');
  this.http.post<Iregister>(this.path + 'register', user , { headers : headers}).subscribe(data => {});
}

login(user: Ilogin) {
  let headers = new HttpHeaders();
  headers = headers.append('Content-Type', 'application/json; charset=UTF-8');
  this.http.post<Ilogin>(this.path + 'login', user , { headers : headers } ).subscribe((data: any) => {
     localStorage.setItem('token', data.token);
     localStorage.setItem('userId', this.jwtHelper.decodeToken(data.token).nameid);
     localStorage.setItem('userName', this.jwtHelper.decodeToken(data.token).unique_name);
     localStorage.setItem('role', this.jwtHelper.decodeToken(data.token).role);
     this.router.navigate(['index']);
  });
}

get token() {
  return localStorage.getItem('token');
}

isLogin() {
  if (localStorage.getItem('token')) {
    return true;
  } else {
    return false;
  }
}

getUser() {
  return localStorage.getItem('userName');
}

logout() {
  localStorage.clear();
}

isAdmin() {
  if ( localStorage.getItem('role') === 'Admin')  {
    return true;
  } else {
    return false;
  }
}

}
