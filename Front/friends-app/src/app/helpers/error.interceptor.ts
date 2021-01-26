import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { AccountService } from './../services/account.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AccountService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            if ([401, 403].indexOf(err.status) !== -1) {

                this.authenticationService.logout();
                location.reload();
            }

            let error: any;
            if (err.error instanceof ErrorEvent) {
                error = `Error: ${err.error}`;
            } else {
                error = this.getServerError(err);
            }

            return throwError(error);
        }))
    }

    private getServerError(error: HttpErrorResponse): {} {
        switch (error.status) {
            case 400: {
                return error;
            }
            case 404: {
                return { Error: `Not Found: ${error.message}` };
            }
            case 403: {
                return {
                    Error: `Access Denied: ${error.message}`
                };
            }
            case 500: {
                return { Error: `Internal Server Error: ${error.message}` };
            }
            default: {
                return { Error: `Unknown Server Error: ${error.message}` };
            }

        }
    }
}
