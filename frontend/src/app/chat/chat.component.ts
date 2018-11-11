import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { environment } from 'src/environments/environment';
import { Message } from '../shared/models/message.model';

@Component({
    selector: 'app-chat',
    templateUrl: './chat.component.html',
    styleUrls: ['./chat.component.sass']
})
export class ChatComponent implements OnInit {

    hubConnection: HubConnection;

    message: Message = { senderName: '', sendAt: new Date(), text: '' };
    messages: Message[] = [];

    isShowDialog = false;
    isAskName = true;

    connect = 'disconnected';
    roles = [];

    constructor() {
    }

    ngOnInit() {
        this.createConection();

        this.receiveMessage();

        setTimeout(() => this.isShowDialog = true, 3000);
    }

    createConection(): void {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(`${environment.server_url}/chatHub`)
            .build();
    }

    receiveMessage(): void {
        this.hubConnection.on('ReceiveMessage', (name, time, text) => {
            if (name === 'JobList Admin') {
                this.roles.push('admin');
            } else {
                this.roles.push('user');
            }
            this.messages.push({ senderName: name, sendAt: time, text: text });
        });
    }

    startConnection(): void {
        this.hubConnection.start()
            .then(() => {
                this.connect = null;
                this.hubConnection.invoke('SetName', this.message.senderName);
            })
            .catch(error => console.log(error));
    }

    sendMessage(): void {
        if (this.message.text) {
            this.hubConnection.invoke('SendMessage', this.message.senderName, this.message.text);
            this.message.text = '';
        }
    }

    closeConnection(): void {
        this.hubConnection.onclose(() => {
            this.connect = 'disconnected';
            console.log('Reconnecting in 5 seconds...');
            setTimeout(this.startConnection, 5000);
        });
    }

    startChat() {
        if (this.message.senderName) {
            this.isAskName = false;
            this.startConnection();
        }
    }
}
