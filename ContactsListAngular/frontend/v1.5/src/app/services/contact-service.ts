import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { Contact } from '../entities/Contact';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContactService {


  modifyContact(p: Contact) {
    return this.http.put<Contact>(environment.backend_url + "/contacts",JSON.stringify(p));
  }

  constructor(private store:Store,private http: HttpClient) { 
  }  
  
  addContact(p:Contact) {
    //Call HTTP service
    //debugger;
    return this.http.post<Contact>(environment.backend_url + "/contacts",JSON.stringify(p));
    
  }

  deleteContact(id:number):Observable<Boolean> {
    //Call HTTP service
    debugger;
    return this.http.delete<Boolean>(environment.backend_url + "/contacts/" + id.toString());
  }

  getContacts() : Observable<Contact[]> 
  {
    return this.http.get<Contact[]>(environment.backend_url + "/contacts");
  }
    
  
}
