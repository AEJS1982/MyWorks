import { Action, createReducer, on } from '@ngrx/store';
import * as ContactActions from '../actions/contacts.actions';
import { appState, currentState } from '../store/state';

const selectedPersonReducer=createReducer(
    currentState,
    on(ContactActions.selectContact, (state,action) => { 
        //debugger;
        return {...state, selectedPerson:action.payload}
    }),
);

export function reducer(state: appState | undefined, action: Action): any {
    return selectedPersonReducer(state, action);
}