import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '..';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {

  }

  isAuthenticated: boolean = false;

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    console.log("Can Activate called.");

    this.authService.isAuthenticated()
      .then(isAuthenticated => {
        this.isAuthenticated = isAuthenticated;
      });

    if (!this.isAuthenticated) {
      return true;
    } else {
      this.router.navigate(["/authentication"]);
    }

    return this.authService.isAuthenticated();
  }

}
