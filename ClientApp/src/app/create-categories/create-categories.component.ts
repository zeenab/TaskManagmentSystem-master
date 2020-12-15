import { Component, OnInit } from '@angular/core';
import { CategoriesViewModel } from '../../models/CategoriesViewModel';
import { CategoriesService } from '../services/categories.service';

@Component({
  selector: 'app-create-categories',
  templateUrl: './create-categories.component.html',
  styleUrls: ['./create-categories.component.css']
})
export class CreateCategoriesComponent implements OnInit {
  submitted = false;

  data: CategoriesViewModel = {
    CategoryId: 0,
    CategoryName:""

  }


  constructor(private service: CategoriesService) { }

  ngOnInit() {
  }


  parseTextToInteger(selected) {
    this.data.CategoryId = parseInt(selected);
  }

  save() {

    this.data;
    this.service.addCategory(this.data)
      .subscribe(response => {

        console.log(response);
        this.submitted = true;
      },
        error => {
          console.log(error);
        });
  }


}
