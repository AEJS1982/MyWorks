import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { Store, StoreModule } from '@ngrx/store';
import { provideMockStore } from '@ngrx/store/testing';
import { Contact } from 'src/app/entities/Contact';
import { User } from 'src/app/entities/user';

import { ContactListComponent } from './contact-list.component';

describe('ContactListComponent', () => {
  let component: ContactListComponent;
  let fixture: ComponentFixture<ContactListComponent>;
  const initialState = {
    users:[],
    userLogged:new User(),
    contacts:[],
    selectedContact:new Contact(0,"","",0,"")
  };

  beforeEach(async () => {

    await TestBed.configureTestingModule({
      declarations: [ ContactListComponent ],
      providers:[
        provideMockStore({initialState})
      ],
      imports:[
        ReactiveFormsModule,
        RouterTestingModule,
        HttpClientTestingModule
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
