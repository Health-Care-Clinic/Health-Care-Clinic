import { Component, OnInit } from '@angular/core';
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
  constructor(private _notificationService : NotificationService) { }

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
  } 
  
  seeNotifications(): void {
    for(let notification of this.notifications){
      notification.seen = true;
    }
    this.unreadNotificationNumber = 0;
  }
}
