import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Person } from '../entities/person';
import { currentState } from '../store/state';


@Injectable({
  providedIn: 'root'
})
export class ContactService {
  

  constructor(private router:Router) { 
    //debugger;
    if (currentState.contacts.length==0) {
      currentState.contacts=[];
      var p1=new Person(1,"King","Diamond",12345678,"kbendix@mf.com");
      currentState.contacts.push(p1);
      var p2=new Person(2,"Michael","Denner",90000001,"mdenner@mf.com");
      currentState.contacts.push(p2);
      var p3=new Person(3,"Hank","Shermann",78891278,"hshermann@mf.com");
      currentState.contacts.push(p3);
    }
  }

  addContact(p:Person):Observable<Person> {
    //debugger;
    currentState.contacts.push(p);    
    this.router.navigate(['/contacts']);
    return of(p);
  }

  deleteContact(id:number) {
    //debugger;
    currentState.contacts=currentState.contacts.filter(x => x.id!=id);
  }

  getContacts() : Observable<Person[]> 
  {
    return of(currentState.contacts);
  }
}
