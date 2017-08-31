import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

import { AuthenticationService } from '../services/index';
import { Task } from '../models/task';

@Injectable()
export class TaskService {
  constructor(
    private http: Http,
    private authenticationService: AuthenticationService) {
  }

  getTasks(): Observable<Task[]> {
    // add authorization header with jwt token
    let headers = new Headers({ 'Authorization': 'Bearer ' + this.authenticationService.token });
    headers.append('Access-Control-Allow-Headers', 'Content-Type');
    headers.append('Access-Control-Allow-Methods', 'GET');
    headers.append('Access-Control-Allow-Origin', '*');
    headers.append('Content-Type', 'application/x-www-form-urlencoded');
    let options = new RequestOptions({ headers: headers });

    // get users from api
    return this.http.get('http://localhost:52954/api/todo/getall', options)
      .map((response: Response) => response.json());
  }
}