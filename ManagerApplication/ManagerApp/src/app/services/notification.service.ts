import { Injectable } from '@angular/core';
import { INotification } from '../model/notification';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor() { }

  getAllNotifications(): INotification[]{
    let date = new Date();
    return [
      {
        "id": 0,
        "title": "Notification 1",
        "content": "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        "date": date,
        "seen": false
      },
      {
        "id": 1,
        "title": "Notification 2",
        "content": "Incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "date": date,
        "seen": false
      },
      {
        "id": 2,
        "title": "Notification 3",
        "content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit sed do eiusmod tempor incididun.",
        "date": date,
        "seen": true
      },
      {
        "id": 3,
        "title": "Notification 4",
        "content": "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "date": date,
        "seen": true
      },
      {
        "id": 4,
        "title": "Notification 5",
        "content": "Consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        "date": date,
        "seen": true
      },
      {
        "id": 5,
        "title": "Notification 6",
        "content": "Ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore.",
        "date": date,
        "seen": true
      },
      {
        "id": 6,
        "title": "Notification 7",
        "content": "Dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.",
        "date": date,
        "seen": true
      }
    ]
  }
}
