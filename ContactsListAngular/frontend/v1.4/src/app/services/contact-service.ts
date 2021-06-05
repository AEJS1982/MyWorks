import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { Person } from '../entities/person';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  contacts:Person[];

  constructor(private store:Store,private http: HttpClient) { 
    this.contacts=[];
  }  
  
  addContact(p:Person):Observable<Person> {
    //Call HTTP service
    return this.http.post<Person>(environment.backend_url + "/contacts", {p});
    
  }

  deleteContact(id:number):Observable<Boolean> {
    //Call HTTP service
    return this.http.delete<Boolean>(environment.backend_url + "/contacts/" + {id});
  }

  getContacts() : Observable<Person[]> 
  {
    return this.http.get<Person[]>(environment.backend_url + "/contacts");
  }
    
  
}
