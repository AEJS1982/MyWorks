import { State } from "@ngrx/store";
import { Person } from "../entities/person";
import { User } from "../entities/user";

export interface appState {
    userLogged: User;
    contacts: Person[];
    selectedPerson: Person;

}

export var myAppState: appState={
    userLogged:new User(),
    contacts:[],
    selectedPerson:{firstName:"",lastName:"",id:0,email:"",phoneNumber:0}
};

