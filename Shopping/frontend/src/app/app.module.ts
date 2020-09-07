import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MyListsComponent } from './components/my-lists/my-lists.component'
import { aListComponent } from './components/a-list/a-list.component';
import { LoginComponent } from './components/login/login.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { wsProxy } from './services/wsproxy';
import { messageService } from './services/messageService';

@NgModule({
  declarations: [
    AppComponent,
    MyListsComponent,
    aListComponent,
    aListComponent,
    LoginComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [messageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
