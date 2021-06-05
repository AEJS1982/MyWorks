import { State } from "@ngrx/store";
import { Person } from "../entities/person";
import { User } from "../entities/user";

export interface appState {
    users:User[];
    userLogged: User;
    contacts: Person[];
    selectedPerson: Person;

}

export const currentState: appState={
    users:[],
    userLogged:new User(),
    contacts:[],
    selectedPerson:new Person(0,"","",0,"")
};


