import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Contact } from 'src/app/entities/Contact';
import { ContactService } from 'src/app/services/contact-service';
import { appState, currentState } from 'src/app/store/state';
import { Store } from '@ngrx/store';
import { addNewContactSuccess, saveContactNew, saveContactEdit } from 'src/app/actions/contacts.actions';
import { getSelectedContact } from 'src/app/selectors/contacts.selectors';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators ,ReactiveFormsModule  } from '@angular/forms';


@Component({
  selector: 'app-contact-editor-v2',
  templateUrl: './contact-editor.component-v2.html',
  styleUrls: ['./contact-editor.component-v2.scss']
})
export class ContactEditorComponentv2 implements OnInit {
  errors:string[];
  editMode:boolean;
  form:FormGroup;
  ContactId:number;
  
  constructor(private fb: FormBuilder,private route: ActivatedRoute,private store: Store<appState>,private cd:ChangeDetectorRef, private cs:ContactService,private router:Router) { 
    this.errors=[];
    this.ContactId=0;

    this.form = this.fb.group({
      firstName: new FormControl('', [Validators.required,Validators.pattern("([A-Za-z]*)")]),
      lastName: new FormControl('',[Validators.required,Validators.pattern("([A-Za-z]*)")]),
      email: new FormControl('',Validators.pattern("([A-Za-z0-9]*)@([A-Za-z0-9]*).com")),
      phoneNumber:new FormControl('',Validators.pattern("^[0-9]*$"))
    });

    this.store.select(getSelectedContact).subscribe(
      data => {
        //debugger;
        this.form.patchValue({
          firstName: data.firstName,
          lastName:data.lastName,
          email:data.email,
          phoneNumber:data.phoneNumber});

          this.ContactId=data.id;
      });
    
    

    this.errors=[];
    this.editMode=false;
  }

  ngOnInit(): void {

    
    this.route.paramMap
    .subscribe((data) => {
      console.log(data);
      if (data.get("ModoOper")=="N") {
        this.form.patchValue({
          firstName: "",
          lastName:"",
          email:"",
          phoneNumber:0});

          this.ContactId=0;
      }
    });
  }

  onSubmit(): void {
    //debugger;
    if (this.form.valid){
      var payload=this.form.value;

      if (!this.editMode) {
        (payload as Contact).id=0;
        this.store.dispatch(saveContactNew({payload}));
      }
      else 
      {
        (payload as Contact).id=this.ContactId;
        this.store.dispatch(saveContactEdit({payload}));
      }

      this.router.navigate(['/contacts']);
    }
  }

  cancel():void {
    this.router.navigate(['/contacts']);
  }

}


