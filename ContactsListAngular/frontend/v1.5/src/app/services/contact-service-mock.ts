import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { setInitialData } from '../actions/contacts.actions';
import { Contact } from '../entities/Contact';
import { currentState } from '../store/state';


@Injectable({
  providedIn: 'root'
})
export class ContactServiceMock {
  

  constructor(private store:Store,private router:Router) { 
    if (currentState.contacts.length==0) {
      var data=[];
      var p1=new Contact(1,"King","Diamond",12345678,"kbendix@mf.com");
      data.push(p1);
      var p2=new Contact(2,"Michael","Denner",90000001,"mdenner@mf.com");
      data.push(p2);
      var p3=new Contact(3,"Hank","Shermann",78891278,"hshermann@mf.com");
      data.push(p3);
      this.store.dispatch(setInitialData({payload:data}));
    }
  }

  addContact(p:Contact):Observable<Contact> {
    //currentState.contacts.push(p);    
    this.router.navigate(['/contacts']);
    return of(p);
  }

  deleteContact(id:number):Observable<number> {
    currentState.contacts=currentState.contacts.filter(x => x.id!=id);
    return of(0);
  }

  getContacts() : Observable<Contact[]> 
  {
    return of(currentState.contacts);
  }
}
