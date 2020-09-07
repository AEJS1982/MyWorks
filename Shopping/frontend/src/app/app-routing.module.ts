import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { MyListsComponent } from './components/my-lists/my-lists.component';
import { aListComponent } from './components/a-list/a-list.component';

const routes: Routes = [ 
  { path: 'login', component: LoginComponent },
  { path: 'lists', component: MyListsComponent },
  { path: 'list', component: aListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
