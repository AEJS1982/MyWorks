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
import { currentState } from './store/state';
import { Person } from './entities/person';

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
    FormsModule
  ],
  providers: [ContactService,authGuard],
  bootstrap: [AppComponent]
})
export class AppModule { 


    
}
