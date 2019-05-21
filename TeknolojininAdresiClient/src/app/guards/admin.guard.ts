import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/_services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate  {
  constructor( private serviceAuth: AuthService, private router: Router) { }

  canActivate(): boolean {
    if (this.serviceAuth.isAdmin()) {
      return true;
    }
    else {
      this.router.navigate(['index']);
      return false;
    }
  }
}
