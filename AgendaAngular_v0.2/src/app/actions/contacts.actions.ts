/* NgRx */
import { createAction, props } from '@ngrx/store';
import { Person } from '../entities/person';

export const getContacts = createAction(
  'getContacts'
);

export const getContactsSuccess = createAction(
    'getContactsSuccess',
    props<{ payload:Person[] }>()
);

export const getContactsError = createAction(
    'getContactsError',
    props<{ error:string }>()
);

export const addContact = createAction(
    'addContact',
    props<{ payload:Person }>()
);

export const addContactSuccess = createAction(
    'addContactSuccess'
);

export const addContactError = createAction(
    'addContactError',
    props<{ error:string }>()
);

export const deleteContact = createAction(
    'deleteContact',
    props<{ payload:Person }>()
);

export const deleteContactSuccess = createAction(
    'deleteContactSuccess'
);

export const deleteContactError = createAction(
    'deleteContactError',
    props<{ error:string }>()
);



