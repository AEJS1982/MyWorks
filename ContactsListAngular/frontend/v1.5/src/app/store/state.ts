import { State } from "@ngrx/store";
import { Contact } from "../entities/Contact";
import { User } from "../entities/user";

export interface appState {
    users:User[];
    userLogged: User;
    contacts: Contact[];
    selectedContact: Contact;
    lastError:string;
}

export const currentState: appState={
    users:[],
    userLogged:new User(),
    contacts:[],
    selectedContact:new Contact(0,"","",0,""),
    lastError:""
};


