import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { ContactItemComponent } from './components/contact-item/contact-item.component';
import { LoginComponent } from './components/login/login.component';
import { ContactService } from './services/contact-service';
import { FormsModule } from '@angular/forms';
import { authGuard } from './guards/authGuard';
import { appState, currentState } from './store/state';
import { Person } from './entities/person';
import { ActionReducerMap, MetaReducer, State, StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { ContactsEffects } from './effects/contacts.effects';
import * as fromContact from './reducers/contacts.reducer';
import * as fromUsers from './reducers/users.reducer';
import * as fromPersona from './reducers/selectedPerson.reducer';
import { environment } from 'src/environments/environment';

let rootReducer = {
  contacts:fromContact.reducer,
  users:fromUsers.reducer,
  selectedPerson: fromPersona.reducer
}

@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    ContactItemComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    StoreModule.forRoot(rootReducer),
    EffectsModule.forRoot([ContactsEffects])
  ],
  providers: [ContactService,authGuard],
  bootstrap: [AppComponent]
})
export class AppModule { 

    
}



  


