import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { Store } from '@ngrx/store';
import { MockStore, provideMockStore } from '@ngrx/store/testing';
import { Person } from '../entities/person';
import { User } from '../entities/user';
import { appState } from '../store/state';

import { ContactServiceMock } from './contact-service-mock';

describe('ContactService', () => {
  let service: ContactServiceMock;
  const initialState = {
    users:[],
    userLogged: new User(),
    contacts:[],
    selectedPerson:new Person(0,"","",0,"")
  };
  
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
      ],
      providers:[
        provideMockStore({initialState})
      ]

    });
    service = TestBed.inject(ContactServiceMock);
    
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
