
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.scss']
})
export class EventComponent implements OnInit {

  public events: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEvents();
  }

  public getEvents(): void {
    this.http
      .get('https://localhost:5001/api/events')
      .subscribe(
        response => this.events = response,
        error => console.log(error)
      );
  }

}
