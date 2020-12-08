import { Component, OnInit } from '@angular/core';
import { TasksViewModel } from '../../models/TasksViewModel';
import { TasksService } from '../services/tasks.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-create-task',
  templateUrl: './create-task.component.html',
  styleUrls: ['./create-task.component.css']
})
export class CreateTaskComponent implements OnInit {
  submitted = false;

  data: TasksViewModel = {
    TaskId: 0,
    Subject: '',
    CreateTime: null,
    StartDate: null,
    DueDate: null,
    CompletedDate: null,
    Complete: false,
    Importance: ''
  }
 

  constructor( private service : TasksService) { }
 
  ngOnInit() {
  }


  parseTextToBoolean(selected) {
    this.data.Complete = Boolean(selected);
  }

  save() {
    
   this.data;
   this.service.addTask(this.data)
     .subscribe(response => {

          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }


}
