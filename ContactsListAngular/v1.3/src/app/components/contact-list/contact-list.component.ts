import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, pipe, Subject } from 'rxjs';
import { Person } from 'src/app/entities/person';
import { ContactService } from 'src/app/services/contact-service';
import { appState, currentState } from 'src/app/store/state';
import { Store } from '@ngrx/store';

import { addNewContact ,deleteContact,editContact, getContacts, selectContact } from 'src/app/actions/contacts.actions';
import { takeUntil, tap } from 'rxjs/operators';
import { getAllContacts } from 'src/app/selectors/contacts.selectors';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.scss']
})
export class ContactListComponent implements OnInit {
  contacts: Person[] | undefined;
  contacts$:Observable<Person[]> | undefined;
  destroy$: Subject<boolean> = new Subject<boolean>();

  constructor(private store: Store<appState>,private cs:ContactService,private router:Router) { 
    this.store.select(getAllContacts).subscribe(data => this.contacts=data.contacts);
  }

  ngOnInit(): void {
    
  }
  
  ngOnDestroy() {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }
  
  addNew(): void {
    //redirect to add person
    var payload=new Person(0,"","",0,"");
    this.store.dispatch(addNewContact({payload}));
    this.router.navigate(['/contact','N','0']);
  }

  getChangeInfo(e: any) {
    console.log(e);
  }

 

}
