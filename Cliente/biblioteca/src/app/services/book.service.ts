import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http:HttpClient) { }
  getBook (value:string): Observable<any> {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json; charset=utf-8');
    //headers.append('dataType', 'application/json');
    //headers.append('Authorization', 'Bearer' + '29aLqSMIBl5DuJXxdt9yX9r5PrxzNuhFR4kIzFn3');
    return this.http.get(`${environment.apiUrl}api/Libros?value=${value}`, { headers });
  }
}
