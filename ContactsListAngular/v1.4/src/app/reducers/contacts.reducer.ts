import { state } from '@angular/animations';
import { Action, createReducer, on } from '@ngrx/store';
import * as ContactActions from '../actions/contacts.actions';
import { Person } from '../entities/person';
import { appState, currentState } from '../store/state';


const contactsReducer=createReducer(
    currentState,
    on(ContactActions.setInitialData, (state,action) => { 
        return {...state, contacts:action.payload}
    }),
    on(ContactActions.getContacts, (state) => { 
        return state} ),
    on(ContactActions.getContactsSuccess, (state,action) => {
        return {...state, contacts:action.payload}
    }),
    on(ContactActions.addNewContact, (state,action) => {
        return {...state, selectedPerson:new Person(0,"","",0,"")} ;
    }),
    on(ContactActions.addNewContactSuccess, (state,action) => {
        debugger;
        var updatedContacts=state.contacts;
        var newPerson=new Person(0,"","",0,"");
        newPerson.firstName=action.payload.firstName;
        newPerson.lastName=action.payload.lastName;
        newPerson.phoneNumber=action.payload.phoneNumber;
        newPerson.email=action.payload.email;
        updatedContacts=updatedContacts.concat(newPerson);
        return {...state, contacts:updatedContacts} ;
    }),
    on(ContactActions.editContact, (state,action) => {
        return {...state, selectedPerson:action.payload} ;
    }),
    on(ContactActions.deleteContact, (state,action) => {
        return {...state, contacts:state.contacts.filter(x => x.id!=action.payload.id)};
        ;
    })
)

export function reducer(state: appState | undefined, action: Action): any {
    return contactsReducer(state, action);
}

