/* NgRx */
import { createAction, props } from '@ngrx/store';
import { Person } from '../entities/person';

export const getContacts = createAction(
  'getContacts'
);

export const setInitialData = createAction(
    'setInitialData',
    props<{ payload:Person[] }>(
    )
);

export const getContactsSuccess = createAction(
    'getContactsSuccess',
    props<{ payload:Person[] }>(
    )
);

export const getContactsError = createAction(
    'getContactsError',
    props<{ error:string }>()
);

export const addNewContact = createAction(
    'addNewContact',
    props<{ payload:Person }>()
);

export const saveContact=createAction('saveContact',props<{ payload:Person }>());

export const editContact = createAction(
    'editContact',
    props<{ payload:Person }>()
);

export const addNewContactSuccess = createAction(
    'addContactSuccess',
    props<{ payload:Person }>()
);

export const addNewContactError = createAction(
    'addContactError',
    props<{ error:string }>()
);

export const deleteContact = createAction(
    'deleteContact',
    props<{ payload:Person }>()
);

export const selectContact = createAction(
    'selectContact',
    props<{ payload:Person }>()
);

export const deleteContactSuccess = createAction(
    'deleteContactSuccess'
);

export const deleteContactError = createAction(
    'deleteContactError',
    props<{ error:string }>()
);


