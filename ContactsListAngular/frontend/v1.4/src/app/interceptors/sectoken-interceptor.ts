import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class SecurityTokenInterceptor implements HttpInterceptor {
    token:string | undefined;
    
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.token!=sessionStorage.getItem("token");
        var headerSet:HttpHeaders;
        headerSet=new HttpHeaders();
        headerSet.append("token","token_1234");
        headerSet.append("Content-type","application/json");

        const authReq = request.clone({
            headers: headerSet
          });
        return next.handle(request);
    }
}