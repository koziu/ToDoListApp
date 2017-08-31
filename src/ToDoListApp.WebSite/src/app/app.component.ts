//import { Component, OnInit } from '@angular/core';
//import { Http, Response } from '@angular/http';
//import 'rxjs/add/operator/map';



//@Component({
//  selector: 'app-root',
//  templateUrl: './app.component.html',
//  styleUrls: ['./app.component.css'],
//  template: `<div *ngFor="let key of objectKeys(items)">{{key + ' : ' + tasks[key]}}</div>`
//})


//export class AppComponent implements OnInit{
//  title = 'ToDoList';
//  private apiUrl = 'http://localhost:52954/api/todo/';
//  objectKeys = Object.keys;
//  tasks: any = {};
//  dtOptions: DataTables.Settings = {};

//  constructor(private http: Http) {
//    console.log("Hello fellow user");
//    this.getTasks();   
//  }

//  getTasks() {
//    return this.http.get(this.apiUrl + 'getall')
//      .map((res: Response) => res.json())
//      .subscribe(data => {
//        console.log(data);
//        this.tasks = data;
//      });
//  }

//  ngOnInit(): void {
//    this.dtOptions = {
//      pagingType: 'full_numbers'
//    };
//  }
//}

import { Component } from '@angular/core';

@Component({
  moduleId: module.id,
  selector: 'app',
  templateUrl: 'app.component.html'
})

export class AppComponent { }