import { Component, OnInit } from '@angular/core';
import { INotification } from '../model/notification';
import { NotificationService } from '../services/notification.service';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {

  notifications : INotification[] = [];
  unreadNotificationNumber: number = 0;
  constructor(private _notificationService : NotificationService) { }

  ngOnInit(): void {
    this._notificationService.getAllNotifications().subscribe(
      notifications => {
        this.notifications = notifications.sort((a, b) => (a.date > b.date ? -1 : 1));
        this.seeNotifications();
      });
    //this.notifications = this._notificationService.getAllNotifications();
    // posalje zahtev na bek da se sve notifikacije postave na seen
  } 
  
  seeNotifications(): void {
    this._notificationService.markAllNotificationsAsSeen().subscribe(res => {
      for(let notification of this.notifications){
        notification.seen = true;
      }
    });
    this.unreadNotificationNumber = 0;
  }
 


}
