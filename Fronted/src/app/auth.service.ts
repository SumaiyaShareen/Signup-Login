import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'http://yourapiurl.com/api'; // Replace with your API URL

  constructor(private http: HttpClient) {}

  signup(userDetails: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/signup`, userDetails);
  }

  login(credentials: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/login`, credentials);
  }
}
