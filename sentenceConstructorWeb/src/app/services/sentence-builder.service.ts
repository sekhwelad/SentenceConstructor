import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SentenceBuilderService {
  hostUrl: string = 'https://localhost:5001';
  constructor(private http: HttpClient) {}

  getAll(): Observable<any> {
    const link = `${this.hostUrl}/api/Products`;
    return this.http.get(link);
  }
}
