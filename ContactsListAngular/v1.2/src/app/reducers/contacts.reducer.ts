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
        var updatedContacts=state.contacts;
        updatedContacts.push(action.payload);
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

