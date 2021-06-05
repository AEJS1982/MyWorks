import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { ContactEditorComponent } from './components/contact-editor/contact-editor.component';
import { LoginComponent } from './components/login/login.component';
import { ContactServiceMock } from './services/contact-service-mock';
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
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ContactService } from './services/contact-service';
import { SecurityTokenInterceptor } from './interceptors/sectoken-interceptor';

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
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    StoreModule.forRoot(rootReducer),
    EffectsModule.forRoot([ContactsEffects])
  ],
  exports:[ReactiveFormsModule],
  providers: [ContactService,authGuard,
    {provide: HTTP_INTERCEPTORS,
    useClass: SecurityTokenInterceptor,
    multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { 

    
}



  


