import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Person } from 'src/app/entities/person';
import { ContactService } from 'src/app/services/contact-service';
import { appState, currentState } from 'src/app/store/state';
import { Store } from '@ngrx/store';
import { addNewContactSuccess, saveContact } from 'src/app/actions/contacts.actions';
import { getSelectedPerson } from 'src/app/selectors/contacts.selectors';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators ,ReactiveFormsModule  } from '@angular/forms';


@Component({
  selector: 'app-contact-editor-v2',
  templateUrl: './contact-editor.component-v2.html',
  styleUrls: ['./contact-editor.component-v2.scss']
})
export class ContactEditorComponentv2 implements OnInit {
  model!: Person;
  errors:string[];
  editMode:boolean;
  form:FormGroup;

  
  constructor(private fb: FormBuilder,private route: ActivatedRoute,private store: Store<appState>,private cd:ChangeDetectorRef, private cs:ContactService,private router:Router) { 
    this.errors=[];

    this.form = this.fb.group({
      firstName: new FormControl('', [Validators.required,Validators.pattern("([A-Za-z]*)")]),
      lastName: new FormControl('',[Validators.required,Validators.pattern("([A-Za-z]*)")]),
      email: new FormControl('',Validators.pattern("([A-Za-z0-9]*)@([A-Za-z0-9]*).com")),
      phoneNumber:new FormControl('',Validators.pattern("^[0-9]*$"))
    });


    this.store.select(getSelectedPerson).subscribe(
      data => {
          this.form.patchValue({
            firstName: data.selectedPerson.firstName,
            lastName:data.selectedPerson.lastName,
            email:data.selectedPerson.email,
            phoneNumber:data.selectedPerson.phoneNumber
          });
        }
      );
   
    this.errors=[];
    this.editMode=false;
  }

  ngOnInit(): void {

    
    this.route.paramMap
    .subscribe((data) => {
      console.log(data);
      if (data.get("ModoOper")=="N") {
        
      }
    });
  }

  onSubmit(): void {
    if (this.form.valid){
      if (!this.editMode) {
        var payload=this.form.value;
        this.store.dispatch(addNewContactSuccess({payload}));
        this.router.navigate(['/contacts']);
      }
      else 
      {
        //TODO:addition of edit mode
      }

    }
  }

  cancel():void {
    this.router.navigate(['/contacts']);
  }

}
