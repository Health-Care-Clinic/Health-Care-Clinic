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
    this.notifications = this._notificationService.getAllNotifications();
    // posalje zahtev na bek da se sve notifikacije postave na seen
  } 
  
 


}
