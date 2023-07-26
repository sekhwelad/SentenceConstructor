import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  IData,
  ISentence,
} from '../sentence-builder/sentence-builder.component';

@Injectable({
  providedIn: 'root',
})
export class SentenceBuilderService {
  hostUrl: string = 'https://localhost:5000';
  apiUrl: string = `${this.hostUrl}/api/v1/SentenceBuilder`;

  headers = { 'content-type': 'application/json' };

  constructor(private http: HttpClient) {}

  getAllWords(): Observable<any[]> {
    const link = `${this.apiUrl}/GetWords`;
    return this.http.get<any[]>(link);
  }

  saveWord(sentence: ISentence): Observable<any> {
    const link = `${this.apiUrl}`;

    var body = JSON.stringify(sentence);

    return this.http.post<any>(link, body, { headers: this.headers });
  }

  getAllSentences(): Observable<ISentence[]> {
    const link = `${this.apiUrl}/GetAllSentences`;
    return this.http.get<ISentence[]>(link);
  }

  getSentences(id: number): Observable<any> {
    const link = `${this.apiUrl}/${id}`;
    return this.http.get<any>(link);
  }
}
