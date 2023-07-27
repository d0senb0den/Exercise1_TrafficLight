import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { interval } from 'rxjs';

@Component({
  selector: 'app-my-component',
  templateUrl: './my-component.component.html',
  styleUrls: ['./my-component.component.css']
})
export class MyComponentComponent implements OnInit {
  constructor(private http: HttpClient) { }

  ngOnInit() {
    /*interval(5000).subscribe(() => {
      this.http.get('https://localhost:7227/TrafficLight').subscribe(data => {
        console.log(data);
      });
    });*/
  }
}
