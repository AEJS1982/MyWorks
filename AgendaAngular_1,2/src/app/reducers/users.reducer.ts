import { Action, createReducer, on } from '@ngrx/store';
import { addNewContact, deleteContact, getContacts } from '../actions/contacts.actions';
import { doLogin } from '../actions/users.actions';
import { appState, currentState } from '../store/state';


const usersReducer=createReducer(
    currentState,
    on(doLogin, (state,payload) => { 
        return state;
    })
   
)


export function reducer(state: appState | undefined, action: Action): any {
    return usersReducer(state, action);
}