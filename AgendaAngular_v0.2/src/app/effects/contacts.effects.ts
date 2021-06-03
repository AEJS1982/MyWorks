import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { of } from "rxjs";
import { map, switchMap, catchError } from "rxjs/operators";
import { addContact, addContactError, addContactSuccess, getContacts, getContactsError, getContactsSuccess } from "../actions/contacts.actions";
import { ContactService } from "../services/contact-service";

@Injectable()
export class ContactsEffects {

    constructor(
        private actions$: Actions,
        private cs: ContactService
    ) {}

    getContacts$ = createEffect(() =>
        this.actions$.pipe(
        ofType(getContacts),
        switchMap(() =>
                this.cs.getContacts().pipe(
                map((res: any) => {
                    return getContactsSuccess(res);
                }),
                catchError(error => {
                    return of(
                    getContactsError(error)
                    );
                })
                )
            )
    ));

    addContact$=createEffect(() => 
        this.actions$.pipe(
            ofType(addContact),
            switchMap(action => this.cs.addContact(action.payload).pipe(
                map((res:any) => {
                    return addContactSuccess()
                }),
                catchError(error => {
                    return of(
                    addContactError(error)
                    );
                })
            ))
    ))

    deleteContact$=createEffect(() => 
        this.actions$.pipe(
            ofType(addContact),
            switchMap(action => this.cs.addContact(action.payload).pipe(
                map((res:any) => {
                    return addContactSuccess()
                }),
                catchError(error => {
                    return of(
                    addContactError(error)
                    );
                })
            ))
    ))
    
}