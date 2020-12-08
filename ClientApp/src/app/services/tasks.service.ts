import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { TasksViewModel } from '../../models/TasksViewModel';
import { catchError } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})


export class TasksService {
  

  _url = 'https://localhost:44321/Tasks/'
   
  constructor(private http: HttpClient) { }


  getAll(): Observable<any[]> {
    return this.http.get<any[]>(this._url + 'GetAllTasks');
  } 

  addTask(task: TasksViewModel) {
  
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    return this.http.post<any>(this._url + 'Create', task, httpOptions);
  }

  delete(id: any) {
    return this.http.delete<any>(`${this._url+'Delete'}/${id}`);
  }

  update(task: TasksViewModel) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    console.log(task)
    return this.http.put<any>(this._url + 'Update', task, httpOptions);
  }



}
