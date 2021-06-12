/* NgRx */
import { createAction, props } from '@ngrx/store';
import { Contact } from '../entities/Contact';

export const getContacts = createAction(
  'getContacts'
);

export const setInitialData = createAction(
    'setInitialData',
    props<{ payload:Contact[] }>(
    )
);

export const getContactsSuccess = createAction(
    'getContactsSuccess',
    props<{ payload:Contact[] }>(
    )
);

export const getContactsError = createAction(
    'getContactsError',
    props<{ error:string }>()
);

export const addNewContact = createAction(
    'addNewContact',
    props<{ payload:Contact }>()
);

export const saveContactNew=createAction('saveContactNew',props<{ payload:Contact }>());
export const saveContactEdit=createAction('saveContactEdit',props<{ payload:Contact }>());

export const editContact = createAction(
    'editContact',
    props<{ payload:Contact }>()
);

export const addNewContactSuccess = createAction(
    'addContactSuccess',
    props<{ payload:Contact }>()
);

export const saveContactSuccess = createAction(
    'saveContactSuccess',
);

export const saveContactError = createAction(
    'saveContactError',
    props<{ payload:string }>()
);


export const addNewContactError = createAction(
    'addContactError',
    props<{ error:string }>()
);

export const deleteContact = createAction(
    'deleteContact',
    props<{ payload:Contact }>()
);

export const selectContact = createAction(
    'selectContact',
    props<{ payload:Contact }>()
);

export const deleteContactSuccess = createAction(
    'deleteContactSuccess'
);

export const deleteContactError = createAction(
    'deleteContactError',
    props<{ error:string }>()
);


