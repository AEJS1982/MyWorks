import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class SecurityTokenInterceptor implements HttpInterceptor {
    token:string | undefined;
    
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.token!=sessionStorage.getItem("token");
        const authReq = request.clone({
            headers: request.headers.set("token", this.token!)
          });
        return next.handle(request);
    }
}