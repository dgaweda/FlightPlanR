import {Injectable} from "@angular/core";
import {MessageService} from "primeng/api";
import {NotificationType} from "../enums/notification-type.enum";

@Injectable({ providedIn: 'root' })
export class NotificationService {

  constructor(private messageService: MessageService) {
  }

  public showNotification(notificationType: NotificationType, message: string, details?: string): void {
    this.messageService.add({
      key: notificationType,
      severity: notificationType,
      summary: message,
      detail: details
    });
  }
}
