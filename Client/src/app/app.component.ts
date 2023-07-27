import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TrafficLightService } from './traffic-light.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(public signalRService: TrafficLightService, private http: HttpClient) { }
  title = 'Exercise1Frontend';
  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addTrafficLightStateListener();
    this.http.get('https://localhost:7227/TrafficLight')
      .subscribe(data => { console.log(data) }) // Todo: Lagra Data och signalRService.data i samma objekt.
    /*interval(5000).subscribe(() => {
      this.http.get('https://localhost:7227/TrafficLight').subscribe(data => {
        console.log(data);
      });
    });*/
  }
}
