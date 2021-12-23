import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }
    
  getAuthStatus() {
    return !!localStorage.getItem('jwtToken');
  }
  
}
