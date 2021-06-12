import { Component, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, Subject } from 'rxjs';
import { deleteContact, selectContact } from 'src/app/actions/contacts.actions';
import { Contact } from 'src/app/entities/Contact';
import { appState } from 'src/app/store/state';

@Component({
  selector: 'app-contact-list-item',
  templateUrl: './contact-list-item.component.html',
  styleUrls: ['./contact-list-item.component.scss']
})
export class ContactListItemComponent implements OnInit {
  @Input() item: Contact;
  @Output() changeDone: Subject<Boolean>;

  constructor(private store: Store<appState>,private router:Router) { 
    this.item=new Contact(0,"","",0,"");
    this.changeDone=new Subject<Boolean>();
  }
  

  ngOnInit(): void {
    
  }

  editContact(p:Contact): void {
    var payload=p;
    this.store.dispatch(selectContact({payload}));
    this.router.navigate(['/contact','E',p.id]);
  }

  deleteContact(p:Contact):void {
    debugger;
    this.store.dispatch(deleteContact({payload:p}));
    this.changeDone.next(true);
  }

}
