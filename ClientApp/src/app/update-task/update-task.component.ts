import { Component, OnInit } from '@angular/core';
import { TasksViewModel } from '../../models/TasksViewModel';
import { TasksService } from '../services/tasks.service';

@Component({
  selector: 'app-update-task',
  templateUrl: './update-task.component.html',
  styleUrls: ['./update-task.component.css']
})
export class UpdateTaskComponent implements OnInit {
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

  constructor(private service: TasksService) { }

  ngOnInit() {
  }

  parseTextToNumber(selected) {
    this.data.TaskId = parseInt(selected);
  }
  parseTextToBoolean(selected) {
    this.data.Complete = Boolean(selected);
  }

  update() {

    this.data;
    this.service.update(this.data)
      .subscribe(response => {

        console.log(response);
        this.submitted = true;
      },
        error => {
          console.log(error);
        });
  }
}
