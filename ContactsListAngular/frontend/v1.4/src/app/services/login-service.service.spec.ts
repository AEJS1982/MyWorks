import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { provideMockStore } from '@ngrx/store/testing';
import { Person } from '../entities/person';
import { User } from '../entities/user';

import { LoginService } from './login-service.service';

describe('LoginService', () => {
  let service: LoginService;
  const initialState = {
    users:[],
    userLogged: new User(),
    contacts:[],
    selectedPerson:new Person(0,"","",0,"")
  };

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule], 
      providers:[
        provideMockStore({initialState})
      ]
    });
    service = TestBed.inject(LoginService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
