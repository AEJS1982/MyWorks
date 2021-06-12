import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactListItemComponent } from './contact-list-item.component';
import {ReactiveFormsModule, FormsModule} from '@angular/forms';
import { Store } from '@ngrx/store';
import { provideMockStore } from '@ngrx/store/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { User } from 'src/app/entities/user';
import { Contact } from 'src/app/entities/Contact';
import { appState } from 'src/app/store/state';

describe('ContactListItemComponent', () => {
  let component: ContactListItemComponent;
  let fixture: ComponentFixture<ContactListItemComponent>;
  const initialState = {
    users:[],
    userLogged:new User(),
    contacts:[
    ],
    selectedContact:new Contact(0,"","",0,"")
  };

  beforeEach(async () => await TestBed.configureTestingModule({
    declarations: [ContactListItemComponent],
    providers: [
      provideMockStore({initialState})
    ],
    imports: [
      RouterTestingModule
    ]
  })
    .compileComponents());

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
