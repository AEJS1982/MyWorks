import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class SecurityTokenInterceptor implements HttpInterceptor {
    token!: string;
    
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        //debugger;
        this.token="";
        
        if (sessionStorage.getItem("token")!=undefined)
           this.token!=sessionStorage.getItem("token");

        const headers = new HttpHeaders({
            'token': this.token,
            'Content-Type': 'application/json'
          });
        
        var clonedReq=request.clone({headers});
        return next.handle(clonedReq);
    }
}