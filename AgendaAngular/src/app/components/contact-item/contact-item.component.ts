import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Person } from 'src/app/entities/person';
import { ContactService } from 'src/app/services/contact-service';
import { appState, currentState } from 'src/app/store/state';
import { Store } from '@ngrx/store';
import { saveContact } from 'src/app/actions/contacts.actions';
import { getSelectedPerson } from 'src/app/selectors/contacts.selectors';
import { Observable } from 'rxjs/internal/Observable';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-contact-item',
  templateUrl: './contact-item.component.html',
  styleUrls: ['./contact-item.component.scss']
})
export class ContactItemComponent implements OnInit {
  model!: Person;
  errors:string[];
  editMode:boolean;

  constructor(private route: ActivatedRoute,private store: Store<appState>,private cd:ChangeDetectorRef, private cs:ContactService,private router:Router) { 
    this.store.select(getSelectedPerson).subscribe(
      data => {
          this.model=data.selectedPerson;
        }
      );
   
    this.errors=[];
    this.editMode=false;
  }

  ngOnInit(): void {
    //debugger;
    this.route.paramMap
    .subscribe((data) => {
      console.log(data);
      if (data.get("ModoOper")=="N") {
        this.model=new Person(0,"","",0,"");
      }
    }
);
  }

  isValidForm(): Boolean {
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
    if (this.isValidForm()){
      if (this.model?.id==0)
        this.store.dispatch(saveContact({payload:this.model}))
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
