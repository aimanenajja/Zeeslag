import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthenticationService } from '../_services/authentication.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private authenticationService: AuthenticationService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((err) => {
        switch (err.status) {
          case 400: {
            return throwError(Object.values(err.error.errors).join('\r\n'));
          }
          case 401: {
            // auto logout if 401 response returned from api
            this.authenticationService.logout();
            return throwError('Bad request: Username or password is incorrect');
          }
          default: {
            return throwError('Unhandled error');
          }
        }
      })
    );
  }
}
