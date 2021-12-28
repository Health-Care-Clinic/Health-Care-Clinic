import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Credentials } from '../model/manager/credentials';
import jwt_decode from 'jwt-decode';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {

  credentials: Credentials = {
    username: '',
    password: ''
  }

  token: string = '';

  constructor(public _loginService: LoginService, private router: Router) { }


  submit(): void {
    this._loginService.logIn(this.credentials).subscribe(      
      data => {
        localStorage.setItem('jwtToken', data)
        let tokeninfo = this.getDecodedAccessToken(data)
        localStorage.setItem('id', tokeninfo.id)
        localStorage.setItem('role', tokeninfo.role)
        console.log('Dobio: ', data)
        this.router.navigateByUrl('/hospital-map').then(() => location.reload());
      },
      error => console.log('Error!', error),
    )
  }

  getDecodedAccessToken(token: string): any {
    try{
        return jwt_decode(token);
    }
    catch(Error){
        return '';
    }
  }
}
