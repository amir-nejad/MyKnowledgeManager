import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { Constants } from '../../configs/constants';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe((err: any) => {
      if (err instanceof HttpErrorResponse) {
        switch ((err as HttpErrorResponse).status) {
          case 0:
            localStorage.setItem(Constants.localStorageErrorPageTitleKey, "Internet Problem");
            localStorage.setItem(Constants.localStorageErrorKey, "Your internet connection lost.");
            break;
          case 400:
            localStorage.setItem(Constants.localStorageErrorPageTitleKey, "400! Bad Request!");
            localStorage.setItem(Constants.localStorageErrorKey, "It seems that you are requested in a bad way.");
            break;
          case 403:
            localStorage.setItem(Constants.localStorageErrorPageTitleKey, "403! Unauthorized!");
            localStorage.setItem(Constants.localStorageErrorKey, "Ow, It seems that you cannot see this page. Are you sure that you have the required permissions?")
            break;
          case 404:
            localStorage.setItem(Constants.localStorageErrorPageTitleKey, "404! Not Found!");
            localStorage.setItem(Constants.localStorageErrorKey, "Oops, The item that you're looking for does not exist.");
            break;
          case 500:
            localStorage.setItem(Constants.localStorageErrorPageTitleKey, "500! Internal Server Error!");
            localStorage.setItem(Constants.localStorageErrorKey, "An internal server error has been occurred. Please try again later.");
            break;
          default:
            localStorage.setItem(Constants.localStorageErrorPageTitleKey, "Error!");
            localStorage.setItem(Constants.localStorageErrorKey, "Somethings went wrong...");
            break;
        }
        this.router.navigateByUrl("/error");
      }

      return throwError(() => new Error());
    });
  }
}
