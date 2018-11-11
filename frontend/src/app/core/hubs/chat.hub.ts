// import { Injectable } from '@angular/core';
// import { HubConnection } from '@aspnet/signalr';
// import signalR = require('@aspnet/signalr');
// import { environment } from 'src/environments/environment';


// @Injectable()
// export class ChatHubService {
//     hubConnection: HubConnection;

//     public messages: string[] = [];
//     public message: string;

//     constructor() {
//         this.createConection();

//         this.hubConnection.on('Send', (message) => {
//             this.messages.push(message);
//         });

//         this.hubConnection.start();
//     }

//     private createConection(): void {
//         this.hubConnection = new signalR.HubConnectionBuilder()
//             .withUrl(`${environment.server_url}/chat`)
//             .build();
//     }

//     send() {
//         this.hubConnection.invoke('Send', this.message);
//         this.message = '';
//       }
// }
