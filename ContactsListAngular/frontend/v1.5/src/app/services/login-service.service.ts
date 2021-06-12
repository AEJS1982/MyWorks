import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Contact } from '../entities/Contact';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  public login(user:string, pwd:string) {
    return this.http.post<string>(environment.backend_url + "/users",{name:user,password:pwd});
  }
}
