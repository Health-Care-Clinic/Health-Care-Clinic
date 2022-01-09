import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private jwtHelper: JwtHelperService) { }
    
  getAuthStatus() {
    return !!localStorage.getItem('jwtToken');
  }

  hasExpired() {
    var token = localStorage.getItem('jwtToken');
    if (this.jwtHelper.isTokenExpired(token || '{}'))
      return true;
    return false;
  }

  isPatient() {
    if (localStorage.getItem("role") == 'patient')
      return true;
    return false;
  }

  getToken() {
   return localStorage.getItem('jwtToken');
  }
}
