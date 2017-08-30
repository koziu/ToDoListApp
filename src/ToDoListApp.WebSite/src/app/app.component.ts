import { Component, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'ToDoList';
  private apiUrl = 'http://localhost:52954/api/todo/';
  tasks: any = {};
  dtOptions: DataTables.Settings = {};

  constructor(private http: Http) {
    console.log("Hello fellow user");
    this.getTasks();   
  }

  getTasks() {
    return this.http.get(this.apiUrl + 'getall')
      .map((res: Response) => res.json())
      .subscribe(data => {
        console.log(data);
        this.tasks = data;
      });
  }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers'
    };
  }
}
