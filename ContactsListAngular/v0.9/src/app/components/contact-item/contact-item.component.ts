import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Person } from 'src/app/entities/person';
import { ContactService } from 'src/app/services/contact-service';
import { myAppState } from 'src/app/store/state';

@Component({
  selector: 'app-contact-item',
  templateUrl: './contact-item.component.html',
  styleUrls: ['./contact-item.component.scss']
})
export class ContactItemComponent implements OnInit {
  model:Person;
  errors:string[];
  editMode:boolean;

  constructor(private cd:ChangeDetectorRef, private cs:ContactService,private router:Router) { 
    this.model=myAppState.selectedPerson;
    this.errors=[];
    this.editMode=false;
  }

  ngOnInit(): void {
    if (myAppState.selectedPerson.id>0)
      this.editMode=true;

    this.model=myAppState.selectedPerson;
    console.log(myAppState.selectedPerson.id);
  }

  isValidForm(): Boolean {
    debugger;
    var validName="^[A-Za-z]*$";
    var validPhone="^[0-9]*$";

    if (!this.model.firstName.match(validName))
      this.errors.push("firstName");

    if (!this.model.lastName.match(validName))
      this.errors.push("lastName");

    if (this.errors.length>0)
      return false;
    else
      return true;
  }

  save(): void {
    //debugger;
    if (this.isValidForm()){
      if (this.model.id==0)
        this.cs.addContact(this.model);
      else 
      {
        //TODO:edit contact
      }

    }
  }

  cancel():void {
    this.router.navigate(['/contacts']);
  }

}
