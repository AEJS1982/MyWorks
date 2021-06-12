import { Action, createReducer, on } from '@ngrx/store';
import * as ContactActions from '../actions/contacts.actions';
import { appState, currentState } from '../store/state';

const selectedContactReducer=createReducer(
    currentState,
    on(ContactActions.selectContact, (state,action) => { 
        return {...state, selectedContact:action.payload}
    }),
);

export function reducer(state: appState | undefined, action: Action): any {
    return selectedContactReducer(state, action);
}