import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Virtual Academy';

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.getAcademies().subscribe( (data: string[]) => console.log(data));
  }

  getAcademies(): Observable<string[]> {
    return this.http.get<string[]>('https://localhost:7034/api/academy/all');
  }
}
