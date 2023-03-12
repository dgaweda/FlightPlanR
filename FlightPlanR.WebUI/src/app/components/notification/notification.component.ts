import {Component, Input, OnInit} from '@angular/core';
import {NotificationService} from "../../services/notification.service";
import {NotificationType} from "../../enums/notification-type.enum";

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit {
  @Input()
  message: string;

  @Input()
  notificationType: NotificationType;

  @Input()
  details?: string;

  constructor(private notificationService: NotificationService) {
    this.message = '';
    this.notificationType = NotificationType.Info;
    this.details = undefined;
  }

  ngOnInit(): void {
    this.notificationService.showNotification(this.notificationType, this.message, this.details);
  }
}
