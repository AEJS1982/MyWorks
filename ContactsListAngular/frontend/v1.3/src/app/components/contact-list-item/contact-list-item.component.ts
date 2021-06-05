import { Component, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, Subject } from 'rxjs';
import { deleteContact, selectContact } from 'src/app/actions/contacts.actions';
import { Person } from 'src/app/entities/person';
import { appState } from 'src/app/store/state';

@Component({
  selector: 'app-contact-list-item',
  templateUrl: './contact-list-item.component.html',
  styleUrls: ['./contact-list-item.component.scss']
})
export class ContactListItemComponent implements OnInit {
  @Input() item: Person;
  @Output() changeDone: Subject<Boolean>;

  constructor(private store: Store<appState>,private router:Router) { 
    this.item=new Person(0,"","",0,"");
    this.changeDone=new Subject<Boolean>();
  }
  

  ngOnInit(): void {
    
  }

  editPerson(p:Person): void {
    var payload=p;
    this.store.dispatch(selectContact({payload}));
    this.router.navigate(['/contact','E',p.id]);
  }

  deletePerson(p:Person):void {
    this.store.dispatch(deleteContact({payload:p}));
    this.changeDone.next(true);
  }

}
