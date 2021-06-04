import { Component, Input, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { User } from 'src/app/entities/user';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  @Input() user:User;
  error:string;

  constructor(private router: Router) { 
    this.user=new User();
    this.error="";
  }

  ngOnInit(): void {
  }

  doLogin(): void {
    if (this.user.accountName=="ADMIN" && this.user.password=="1234")
    {
      sessionStorage.setItem("isLoginOK","true");
      this.router.navigate(['/contacts']);
    }
    else {
      this.error="Login Incorrect";
    }

  }

}
