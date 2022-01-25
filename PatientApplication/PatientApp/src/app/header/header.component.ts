import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ScheduleEvent } from '../service/event';
import { EventService } from '../service/event.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  role: any

  constructor(private router: Router, private _eventService: EventService) { }

  ngOnInit(): void {
    this.role = localStorage.getItem('role')
  }

  goToLandingPage() {
    if (this.router.url == '/standard-scheduling') {
      this._eventService.eventQueue.push(new ScheduleEvent('End-session', Number(localStorage.getItem('id'))))
      this._eventService.finishEventSession(false).subscribe()
    }
      

    this.router.navigateByUrl('/'); 
  }

  goToFeedbackForm() {
    if (this.router.url == '/standard-scheduling') {
      this._eventService.eventQueue.push(new ScheduleEvent('End-session', Number(localStorage.getItem('id'))))
      this._eventService.finishEventSession(false).subscribe()
    }
      
    this.router.navigateByUrl('/feedback-form');
  }

  goToRegistrationForm() {
    if (this.router.url == '/standard-scheduling') {
      this._eventService.eventQueue.push(new ScheduleEvent('End-session', Number(localStorage.getItem('id'))))
      this._eventService.finishEventSession(false).subscribe()
    }

    this.router.navigateByUrl('/register');
  }

  goToMedicalRecord() {
    if (this.router.url == '/standard-scheduling') {
      this._eventService.eventQueue.push(new ScheduleEvent('End-session', Number(localStorage.getItem('id'))))
      this._eventService.finishEventSession(false).subscribe()
    }
    
    this.router.navigateByUrl('/medical-record');
  }

  logOut() {
    if (this.router.url == '/standard-scheduling') {
      this._eventService.eventQueue.push(new ScheduleEvent('End-session', Number(localStorage.getItem('id'))))
      this._eventService.finishEventSession(false).subscribe()
    }
    
    localStorage.removeItem('id')
    localStorage.removeItem('jwtToken')
    localStorage.removeItem('role')

    this.role = ''

    this.goToLandingPage()
  }

}
