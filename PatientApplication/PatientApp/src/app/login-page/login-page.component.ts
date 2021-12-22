import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Credentials } from '../patient/credentials';
import { PatientService } from '../patient/patient.service';
import jwt_decode from 'jwt-decode';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  credentials: Credentials = {
    username: '',
    password: ''
  }

  token: string = '';

  constructor(public _patientservice: PatientService, private router: Router) { }

  ngOnInit(): void {
  }


  submit(): void {
    this._patientservice.logIn(this.credentials).subscribe(      
      data => {
        localStorage.setItem('jwtToken', data)
        let tokeninfo = this.getDecodedAccessToken(data)
        localStorage.setItem('id', tokeninfo.id)
        localStorage.setItem('role', tokeninfo.role)
        console.log('Dobio: ', data)
        this.router.navigateByUrl('/medical-record');
        /* location.reload()
        this.router.navigateByUrl('/medical-record'); */
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
