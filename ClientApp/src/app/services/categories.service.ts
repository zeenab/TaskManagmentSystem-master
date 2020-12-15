import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CategoriesViewModel } from '../../models/CategoriesViewModel';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {


  _url = 'https://localhost:44321/Categories/'

  constructor(private http: HttpClient) { }


  getAll(): Observable<any[]> {
    return this.http.get<any[]>(this._url + 'GetAllCategories');
  }

  

  delete(id: any) {
    return this.http.delete<any>(`${this._url + 'Delete'}/${id}`);
  }

  addCategory(category: CategoriesViewModel) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    return this.http.post<any>(this._url + 'Create', category, httpOptions);
  }

  update(category: CategoriesViewModel) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    return this.http.put<any>(this._url + 'Update', category, httpOptions);
  }
}
