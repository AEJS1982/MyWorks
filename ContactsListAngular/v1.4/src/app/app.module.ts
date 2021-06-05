import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { ContactEditorComponent } from './components/contact-editor/contact-editor.component';
import { LoginComponent } from './components/login/login.component';
import { ContactService } from './services/contact-service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { authGuard } from './guards/authGuard';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { ContactsEffects } from './effects/contacts.effects';
import * as fromContact from './reducers/contacts.reducer';
import * as fromUsers from './reducers/users.reducer';
import * as fromPersona from './reducers/selectedPerson.reducer';
import { ContactListItemComponent } from './components/contact-list-item/contact-list-item.component';
import { ContactEditorComponentv2 } from './components/contact-editor-v2/contact-editor.component-v2';

let rootReducer = {
  contacts:fromContact.reducer,
  users:fromUsers.reducer,
  selectedPerson: fromPersona.reducer
}

@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    ContactEditorComponent,
    ContactEditorComponentv2,
    LoginComponent,
    ContactListItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    StoreModule.forRoot(rootReducer),
    EffectsModule.forRoot([ContactsEffects])
  ],
  exports:[ReactiveFormsModule],
  providers: [ContactService,authGuard],
  bootstrap: [AppComponent]
})
export class AppModule { 

    
}



  

