import { Component, Input, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { User } from 'src/app/entities/user';
import {NgForm} from '@angular/forms';
import { LoginService } from 'src/app/services/login-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  @Input() user:User;
  error:string;

  constructor(private router: Router,private loginSvc:LoginService) { 
    this.user=new User();
    this.error="";
  }

  ngOnInit(): void {
  }

  doLogin(): void {
    this.loginSvc.login(this.user.accountName,this.user.password).subscribe(
      data => {
        debugger;
        if (data.length>0) {
          sessionStorage.setItem("token",data);
          sessionStorage.setItem("isLoginOK","true");
        }
        else {
          sessionStorage.setItem("isLoginOK","false");
        }
      },
      error => {
        debugger;
        console.log(error);
      }
    )
        

  }

}
