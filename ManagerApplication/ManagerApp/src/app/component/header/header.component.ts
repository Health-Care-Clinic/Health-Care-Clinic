import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { INotification } from 'src/app/model/notification';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  notifications : INotification[] = [];
  unreadNotificationNumber: number = 0;
  role : any
  constructor(private _notificationService : NotificationService, private router: Router) { }

  ngOnInit(): void {
    this._notificationService.getAllNotifications().subscribe(
      notifications => {
        this.notifications = notifications;
        for(let notification of this.notifications){
          if (notification.seen === false){
            this.unreadNotificationNumber +=1;
          }
        }
      }
      );
    this.role = localStorage.getItem('role');
  } 
  
  seeNotifications(): void {
    for(let notification of this.notifications){
      notification.seen = true;
    }
    this.unreadNotificationNumber = 0;
  }

  logout() {
    localStorage.removeItem('id')
    localStorage.removeItem('jwtToken')
    localStorage.removeItem('role')

    this.role = ''

    this.router.navigateByUrl('/');
  }
}
