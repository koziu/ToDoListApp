import { Component, OnInit } from '@angular/core';
import { RouterModule  } from '@angular/router';
import { Task } from '../models/task';
import { TaskService } from '../services/index';

@Component({
  moduleId: module.id,
  templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {
  tasks: Task[] = [];

  constructor(private taskService: TaskService) { }

  ngOnInit() {
    // get users from secure api end point
    this.taskService.getTasks()
      .subscribe(tasks => {
        this.tasks = tasks;
      });
  }

}