import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { Store } from '@ngrx/store';
import {HttpClientTestingModule} from '@angular/common/http/testing';

import { ContactService } from './contact-service';
import { provideMockStore } from '@ngrx/store/testing';
import { User } from '../entities/user';
import { Contact } from '../entities/Contact';

describe('ContactService', () => {
  let service: ContactService;
  const initialState = {
    users:[],
    userLogged: new User(),
    contacts:[],
    selectedContact:new Contact(0,"","",0,"")
  };

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[HttpClientTestingModule],
      providers:[
        provideMockStore({initialState})
      ]
    });
    service = TestBed.inject(ContactService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
