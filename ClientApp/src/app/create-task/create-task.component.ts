import { Component, OnInit } from '@angular/core';
import { TasksViewModel } from '../../models/TasksViewModel';
import { TasksService } from '../services/tasks.service';
import { NgForm } from '@angular/forms';
import { CategoriesViewModel } from '../../models/CategoriesViewModel';
import { CategoriesService } from '../services/categories.service';
import { TasksCategoriesViewModel } from '../../models/tasksCategoriesViewModel';

@Component({
  selector: 'app-create-task',
  templateUrl: './create-task.component.html',
  styleUrls: ['./create-task.component.css']
})
export class CreateTaskComponent implements OnInit {
  submitted = false;
  categoriesList: CategoriesViewModel[] = [];

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
  
  categoryData: CategoriesViewModel = {
    CategoryId: 0,
    CategoryName:""
  }

  tasksCategories: TasksCategoriesViewModel = {
    TaskId: this.data.TaskId,
    CategoryId: this.categoryData.CategoryId
  }
  constructor(private service: TasksService, private service1: CategoriesService) { }
 
  ngOnInit() {
    this.getCategories();
  }


  parseTextToBoolean(selected) {
    this.data.Complete = Boolean(selected);
  }



  getCategories() {
    this.service1.getAll().subscribe(
      data => {
        this.categoriesList = data;
        console.log(data);
      },
      error => {
        console.log(error);
      });
  }



  save() {
    
    this.data;
    this.tasksCategories;

    this.service.addTask(this.data).subscribe(response => {
      console.log(response);
      this.submitted = true;
    },
      error => {
        console.log(error);
      });
    this.service.addTaskCategory(this.tasksCategories).subscribe(response => {
      console.log(response);
      this.submitted = true;
    },
      error => {
        console.log(error);
      });


  }


}
