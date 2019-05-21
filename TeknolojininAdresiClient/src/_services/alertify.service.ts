import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }

error(message: string) {
  alertify.error(message);
}

success(message: string) {
  alertify.success(message);
}

message(message: string) {
  alertify.message(message);
}

warning(message: string) {
  alertify.warning(message);
}

}
