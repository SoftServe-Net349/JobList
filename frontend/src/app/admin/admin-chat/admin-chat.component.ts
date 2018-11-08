import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { environment } from 'src/environments/environment';
import { Message } from 'src/app/shared/models/message.model';
import { Room } from 'src/app/shared/models/room.model';


@Component({
    selector: 'app-admin-chat',
    templateUrl: './admin-chat.component.html',
    styleUrls: ['./admin-chat.component.sass']
})
export class AdminChatComponent implements OnInit {

    chatConnection: HubConnection;
    adminConnection: HubConnection;

    activeRoomId = '';

    messages: Message[] = [];
    message: Message = { senderName: '', sendAt: new Date(), text: '' };

    rooms: Room[] = [];

    isActives: string[] = [];

    constructor() {
    }

    ngOnInit() {
        this.createChatConection();
        this.createAdminConnection();

        this.receiveChatMessage();
        this.receiveMessages();

        this.startChatConnection();
        this.startAdminConnection();

        this.loadRooms();
    }

    createChatConection(): void {
        this.chatConnection = new signalR.HubConnectionBuilder()
            .withUrl(`${environment.server_url}/chat`)
            .build();
    }

    createAdminConnection(): void {
        this.adminConnection = new signalR.HubConnectionBuilder()
            .withUrl(`${environment.server_url}/adminHub`)
            .build();
    }

    startChatConnection(): void {
        this.chatConnection.start()
            .catch(error => console.log(error));
    }

    startAdminConnection(): void {
        this.adminConnection.start()
            .catch(error => console.log(error));
    }

    closeChatConnection(): void {
        this.chatConnection.onclose(() => {
            console.log('Reconnecting in 5 seconds...');
            setTimeout(this.startChatConnection, 5000);
        });
    }

    closeAdminConnection(): void {
        this.adminConnection.onclose(() => {
            console.log('Reconnecting in 5 seconds...');
            setTimeout(this.startAdminConnection, 5000);
        });
    }

    receiveChatMessage(): void {
        this.chatConnection.on('ReceiveMessage', (name, time, text) => {
            this.messages.push({ senderName: name, sendAt: time, text: text });
        });
    }

    receiveMessages(): void {
        this.adminConnection.on('ReceiveMessages', (messages: Message[]) => {
            messages.forEach((message: Message) => {
                this.messages.push({
                    senderName: message.senderName,
                    sendAt: message.sendAt,
                    text: message.text });
            });
        });
    }

    sendMessage(): void {
        if (this.message.text) {
            this.adminConnection.invoke('SendAgentMessage', this.activeRoomId, this.message.text);
            this.message.text = '';
        }
    }

    loadRooms(): void {
        this.adminConnection.on('ActiveRooms', (rooms) => {
            if (!rooms) { return; }

            const roomIds = Object.keys(rooms);
            if (!roomIds.length) { return; }

            this.switchActiveRoomTo(null);
            this.rooms = [];

            roomIds.forEach(id => {
                const roomInfo = rooms[id];
                if (!roomInfo.name) { return; }

                this.rooms.push({ id: id, name: roomInfo.name });
            });
        });
    }

    switchActiveRoomTo(id): void {
        if (id === this.activeRoomId) { return; }

        if (this.activeRoomId) {
            this.chatConnection.invoke('LeaveRoom', this.activeRoomId);
        }

        this.activeRoomId = id;
        this.messages = [];

        if (!id) { return; }

        this.chatConnection.invoke('JoinRoom', this.activeRoomId);
        this.adminConnection.invoke('LoadHistory', this.activeRoomId);
    }

    changeRoom(roomId, index) {
        this.isActives = [];
        this.isActives[index] = 'active';
        this.switchActiveRoomTo(roomId);
    }
}
