import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { of } from "rxjs";
import { map, switchMap, catchError, tap } from "rxjs/operators";
import * as ContactActions from "../actions/contacts.actions";
import { Person } from "../entities/person";
import { ContactService } from "../services/contact-service";

@Injectable()
export class ContactsEffects {

    constructor(
        private actions$: Actions,
        private cs: ContactService
    ) {}

    getContacts$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(ContactActions.getContacts),
            switchMap(action => {
                    console.log(action);

                    return this.cs.getContacts().pipe(
                        map((res: Person[]) => {
                            return ContactActions.getContactsSuccess({payload:res})
                            }
                        ),
                        catchError(error => {
                            return of(
                                ContactActions.getContactsError(error)
                            );
                        })
                    )}
            ))
    });

    saveContact$=createEffect(() =>  {
        return this.actions$.pipe(
            ofType(ContactActions.saveContact),
            switchMap(action => this.cs.addContact(action.payload).pipe(
                map((res:any) => {
                    return ContactActions.addNewContactSuccess(res)
                }),
                catchError(error => {
                    return of(
                    ContactActions.addNewContactError(error)
                    );
                })
            ))
    )})

    /*deleteContact$=createEffect(() => 
        this.actions$.pipe(
            ofType(ContactActions.deleteContact),
            switchMap(action => this.cs.deleteContact(action.payload.id).pipe(
                map((res:any) => {
                    return ContactActions.deleteContactSuccess()
                }),
                catchError(error => {
                    return of(
                        ContactActions.deleteContactError(error)
                    );
                })
            ))
    ))*/
    
}