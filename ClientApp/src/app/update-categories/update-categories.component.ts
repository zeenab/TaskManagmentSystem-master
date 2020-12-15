import { Component, OnInit } from '@angular/core';
import { CategoriesViewModel } from '../../models/CategoriesViewModel';
import { CategoriesService } from '../services/categories.service';

@Component({
  selector: 'app-update-categories',
  templateUrl: './update-categories.component.html',
  styleUrls: ['./update-categories.component.css']
})
export class UpdateCategoriesComponent implements OnInit {
  submitted = false;

  data: CategoriesViewModel = {
    CategoryId: 0,
    CategoryName:""
  }

  constructor(private service: CategoriesService) { }

  ngOnInit() {
  }

  parseTextToNumber(selected) {
    this.data.CategoryId = parseInt(selected);
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
