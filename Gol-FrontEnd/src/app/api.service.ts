import { NgForm } from '@angular/forms';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Travel } from './../models/travel';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

const apiUrl = 'http://localhost:33965/api';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getAllTravels() {
    return this.http.get<Array<Travel>>(`${apiUrl}/Travel/GetAll`)
      .pipe(
        catchError(this.handleError('gatAllTravels', []))
      );
  }

  getTravel(id: number) {
    const url = `${apiUrl}/Travel/GetById/${id}`;
    return this.http.get<Travel>(url).pipe(
      catchError(this.handleError<Travel>(`getTravel id=${id}`))
    );
  }

  addTravel(travel: Travel) {
    return this.http.post<Travel>(`${apiUrl}/Travel/Insert`, travel, httpOptions).pipe(
      catchError(this.handleError<Travel>('addTravel'))
    );
  }

  Authenticate(travel: { travel: string, password: string }) {
    return this.http.post(`${apiUrl}/Auth/Authenticate`, travel, httpOptions).pipe(
      catchError(this.handleError('Authenticate'))
    );
  }

  Register(travel: { travel: string, password: string }) {
    return this.http.post(`${apiUrl}/Auth/Register`, travel, httpOptions).pipe(
      catchError(this.handleError('Register'))
    );
  }

  updateTravel(travel: Travel) {
    const url = `${apiUrl}/Travel/Update`;
    return this.http.put(url, travel, httpOptions).pipe(
      catchError(this.handleError<any>('updateTravel'))
    );
  }

  deleteTravel(id: number) {
    const url = `${apiUrl}/Travel/Delete/${id}`;

    return this.http.delete<Travel>(url, httpOptions).pipe(
      catchError(this.handleError<Travel>('deleteTravel'))
    );
  }

  post(url: string, data: any) {

    return this.http.post(`${apiUrl}/${url}`, data, {
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      }
    }).toPromise();
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error);

      return of(result as T);
    };
  }
}
