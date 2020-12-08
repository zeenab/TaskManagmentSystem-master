import { Component, OnInit } from '@angular/core';
import { TasksViewModel } from '../../models/TasksViewModel';
import { TasksService} from '../services/tasks.service'

@Component({
  selector: 'app-fetch-tasks',
  templateUrl: './fetch-tasks.component.html',
  styleUrls: ['./fetch-tasks.component.css']
})
export class FetchTasksComponent implements OnInit {

  tasksList: TasksViewModel[]=[];
    message: string;

  constructor(private service: TasksService) { }
  ngOnInit() {
    this.getdata();
  }

  getdata() {
    this.service.getAll().subscribe(
      data => {
        this.tasksList = data;
        console.log(data);
      },
      error => {
        console.log(error);
      });
  
  }

  delete(id:any) {
    this.service.delete(id)
      .subscribe(
        response => {
          console.log(response);
          this.getdata();
        },
        error => {
          console.log(error);
        });
  }

  


}
