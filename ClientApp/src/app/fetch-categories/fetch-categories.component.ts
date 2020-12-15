import { Component, OnInit } from '@angular/core';
import { CategoriesViewModel } from '../../models/CategoriesViewModel';
import { CategoriesService } from '../services/categories.service';

@Component({
  selector: 'app-fetch-categories',
  templateUrl: './fetch-categories.component.html',
  styleUrls: ['./fetch-categories.component.css']
})
export class FetchCategoriesComponent implements OnInit {
  categoriesList: CategoriesViewModel[] = [];
  message: string;

  constructor(private service: CategoriesService) { }
  ngOnInit() {
    this.getdata();
  }

  getdata() {
    this.service.getAll().subscribe(
      data => {
        this.categoriesList = data;
        console.log(data);
      },
      error => {
        console.log(error);
      });

  }

  delete(id: any) {
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
