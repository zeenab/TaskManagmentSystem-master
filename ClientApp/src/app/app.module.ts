import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { FetchTasksComponent } from './fetch-tasks/fetch-tasks.component';
import { CreateTaskComponent } from './create-task/create-task.component';
import { TasksService } from './services/tasks.service';
import { UpdateTaskComponent } from './update-task/update-task.component';
import { FetchCategoriesComponent } from './fetch-categories/fetch-categories.component';
import { CategoriesService } from './services/categories.service';
import { CreateCategoriesComponent } from './create-categories/create-categories.component';
import { UpdateCategoriesComponent } from './update-categories/update-categories.component';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    FetchTasksComponent,
    CreateTaskComponent,
    UpdateTaskComponent,
    FetchCategoriesComponent,
    CreateCategoriesComponent,
    UpdateCategoriesComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'fetch-tasks', component: FetchTasksComponent},
      { path: 'create-task', component: CreateTaskComponent },
      { path: 'update-task', component: UpdateTaskComponent },
      { path: 'fetch-categories', component: FetchCategoriesComponent },
      { path: 'create-category', component: CreateCategoriesComponent },
      { path: 'update-category', component: UpdateCategoriesComponent },
    ])
  ], 
  providers: [TasksService, CategoriesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
