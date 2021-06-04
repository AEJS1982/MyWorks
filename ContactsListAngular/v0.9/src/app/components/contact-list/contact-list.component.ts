import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Person } from 'src/app/entities/person';
import { ContactService } from 'src/app/services/contact-service';
import { myAppState } from 'src/app/store/state';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.scss']
})
export class ContactListComponent implements OnInit {
  contacts$ : Observable<Person[]>;
  contacts:Person[];

  constructor(private cs:ContactService,private router:Router) { 
    this.contacts$=this.cs.getContacts();
    this.contacts=[];
    this.cs.getContacts().subscribe(data => {
      this.contacts=data;
    });
  }

  ngOnInit(): void {
    
  }

  addNew(): void {
    //redirect to add person
    myAppState.selectedPerson=new Person(0,"","",0,"");
    this.router.navigate(['/contact']);
  }

  editPerson(p:Person): void {
    //redirect to edit person
    myAppState.selectedPerson=p;
    this.router.navigate(['/contact']);
  }

  deletePerson(p:Person):void {
    this.cs.deleteContact(p.id);
    this.contacts$=this.cs.getContacts();
  }

}
