import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactItemComponent } from './components/contact-item/contact-item.component';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { LoginComponent } from './components/login/login.component';
import { authGuard } from './guards/authGuard';

const routes: Routes = [
  { path: '', component:LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'contacts', component: ContactListComponent, canActivate:[authGuard] },
  { path: 'contact', component:ContactItemComponent , canActivate:[authGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
