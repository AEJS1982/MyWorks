import { parseI18nMeta } from '@angular/compiler/src/render3/view/i18n/meta';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Person } from '../entities/person';
import { myAppState } from '../store/state';


@Injectable({
  providedIn: 'root'
})
export class ContactService {
  

  constructor(private router:Router) { 
    //debugger;
    if (myAppState.contacts.length==0) {
      myAppState.contacts=[];
      var p1=new Person(1,"asdasd","asdasd",12345678,"asdasd@asdasd.com");
      myAppState.contacts.push(p1);
      var p2=new Person(2,"qweqwe","qweqwe",90000001,"qweqwe@qweqwe.com");
      myAppState.contacts.push(p2);
      var p3=new Person(3,"zxczxc","zxczxc",78891278,"zxczxc@zxczxc.com");
      myAppState.contacts.push(p3);
    }
  }

  addContact(p:Person) {
    //debugger;
    myAppState.contacts.push(p);    
    this.router.navigate(['/contacts']);
  }

  deleteContact(id:number) {
    debugger;
    myAppState.contacts=myAppState.contacts.filter(x => x.id!=id);
  }

  getContacts() : Observable<Person[]> 
  {
    return of(myAppState.contacts);
  }
}
