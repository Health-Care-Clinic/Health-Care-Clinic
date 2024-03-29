import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  role: any

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.role = localStorage.getItem('role')
  }

  goToLandingPage() {
    this.router.navigateByUrl('/');
  }

  goToFeedbackForm() {
    this.router.navigateByUrl('/feedback-form');
  }

  goToRegistrationForm() {
    this.router.navigateByUrl('/register');
  }

  goToMedicalRecord() {
    this.router.navigateByUrl('/medical-record');
  }
  
  goToPrescriptions()
  {
    this.router.navigateByUrl('/prescriptions');
  }

  logOut() {
    localStorage.removeItem('id')
    localStorage.removeItem('jwtToken')
    localStorage.removeItem('role')

    this.role = ''

    this.goToLandingPage()
  }

}
