import { EventEmitter, Injectable } from '@angular/core';

import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { environment } from '../../../environments/environment';
import { AuthHelper } from '../../shared/helpers/auth-helper';
import { InvitationRequest } from '../../shared/models/invitation-request.model';
import { Invitation } from '../../shared/models/invitation.model';

@Injectable()
export class InvitationHubService {

  private _hubConnection: HubConnection | undefined;

  invitationReceived = new EventEmitter<Invitation>();
  connectionEstablished = new EventEmitter<Boolean>();

  private connectionIsEstablished = false;

  constructor(private authHelper: AuthHelper) {

    this.startHubConection();

  }

  private createConection(): void {

    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`http://localhost:56681/invitationHub?token=${this.authHelper.getToken()}`)
      .build();

      console.log('Create Hub Conection', this.authHelper.isAuthenticated());
  }

  private startHubConection(): void {

    console.log('Start Hub Conection', this.authHelper.isAuthenticated());

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

    this._hubConnection.on('receiveInvitation', (data: Invitation) => {

      this.invitationReceived.emit(data);

    });

  }

  send(invitation: InvitationRequest) {
    if (this._hubConnection) {
      this._hubConnection.invoke('SendInvitation', invitation)
        .catch(err => console.error(err));
    }
  }

  delete(id: number) {
    if (this._hubConnection) {
      this._hubConnection.invoke('DeleteInvitation', id)
        .catch(err => console.error(err));
    }
  }

  disconnect() {
    this.invitationReceived = new EventEmitter<Invitation>();
    this.connectionEstablished = new EventEmitter<Boolean>();
  }
}
