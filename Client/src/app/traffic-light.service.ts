import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr"

@Injectable({
  providedIn: 'root',
})
export class TrafficLightService {
  public data: string = "";

  private hubConnection: signalR.HubConnection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:7227/trafficLightHub')
    .build();
    public startConnection = () => {
      this.hubConnection
        .start()
        .then(() => console.log('Connection started'))
        .catch(err => console.log('Error while starting connection: ' + err))
  }

  public addTrafficLightStateListener = () => {
    this.hubConnection.on('TrafficLightStateChange', (data) => {
      this.data = data;
      console.log(data);
    });
  }
}
