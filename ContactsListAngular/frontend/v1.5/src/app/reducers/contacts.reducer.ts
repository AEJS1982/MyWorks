import { state } from '@angular/animations';
import { Action, createReducer, on } from '@ngrx/store';
import * as ContactActions from '../actions/contacts.actions';
import { Contact } from '../entities/Contact';
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
        return {...state, selectedContact:new Contact(0,"","",0,"")} ;
    }),
    on(ContactActions.addNewContactSuccess, (state,action) => {
        var updatedContacts=state.contacts;
        var newContact=new Contact(0,"","",0,"");
        newContact.firstName=action.payload.firstName;
        newContact.lastName=action.payload.lastName;
        newContact.phoneNumber=action.payload.phoneNumber;
        newContact.email=action.payload.email;
        updatedContacts=updatedContacts.concat(newContact);
        return {...state, contacts:updatedContacts} ;
    }),
    on(ContactActions.editContact, (state,action) => {
        return {...state, selectedContact:action.payload} ;
    }),
    on(ContactActions.deleteContact, (state,action) => {
        return {...state, contacts:state.contacts.filter(x => x.id!=action.payload.id)};
        ;
    }),
    on(ContactActions.saveContactSuccess, (state,action) => {
        return state;
    }),
    on(ContactActions.saveContactError, (state,action) => {
        return {...state, lastError:action.payload};
    })


)

export function reducer(state: appState | undefined, action: Action): any {
    return contactsReducer(state, action);
}

