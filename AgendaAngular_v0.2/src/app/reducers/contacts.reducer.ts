import { Action, createReducer, on } from '@ngrx/store';
import { addContact, deleteContact, getContacts } from '../actions/contacts.actions';
import { currentState } from '../store/state';


const contactsReducer=createReducer(
    currentState,
    on(getContacts, (state) => { 
        return state} ),
    on(addContact, (state,action) => {
        state.contacts.push(action.payload);
        return state;
    }),
    on(deleteContact, (state,action) => {
        state.contacts=state.contacts.filter(x => x.id!=action.payload.id);
        return state;
    })
)

