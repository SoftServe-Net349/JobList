import { EventEmitter, Injectable } from '@angular/core';

import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { environment } from '../../../environments/environment';
import { AuthHelper } from '../../shared/helpers/auth-helper';

@Injectable()
export class InvitationHubService {

  private _hubConnection: HubConnection | undefined;

  invitationReceived = new EventEmitter<string>();
  connectionEstablished = new EventEmitter<Boolean>();

  private connectionIsEstablished = false;

  constructor(private authHelper: AuthHelper) {

    this.startHubConection();

  }

  private createConection(): void {

    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`http://localhost:56681/invitationHub?token=${this.authHelper.getToken()}`)
      .configureLogging(signalR.LogLevel.Information)
      .build();
  }

  private startHubConection(): void {

    if (!this.authHelper.isAuthenticated()) { return; }
    if (this.connectionIsEstablished) { return; }

    this.createConection();

    this._hubConnection.start()
    .then(() => {
      this.connectionIsEstablished = true;
      this.connectionEstablished.emit(true);
      this.registerOnServerEvents();
    })
    .catch(err => {
      console.error('Error while establishing connection, retrying...');
      setTimeout(this.startHubConection(), 5000);
    });

  }

  private registerOnServerEvents(): void {

    this._hubConnection.on('receiveInvitation', (data: any) => {

      this.invitationReceived.emit(data);

    });

  }

  disconnect() {
    this.invitationReceived = new EventEmitter<string>();
    this.connectionEstablished = new EventEmitter<Boolean>();
  }
}
