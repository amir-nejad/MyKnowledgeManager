import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '..';

// This guard is used for checking if the user is authenticated and can access to a specific URL or not.
@Injectable({
  providedIn: 'root'
})
export class AuthenticationGuard implements CanActivate {
  constructor(private _authService: AuthService, private router: Router) {

  }

  isAuthenticated: boolean = false;

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    this._authService.loginChanged$
    .subscribe(res => {
      this.isAuthenticated = res;
    })


    if (!this.isAuthenticated) {
      this._authService.login();
      return false;
    }

    return this._authService.isAuthenticated();
  }

}
