// src/app/sentence-builder/sentence-builder.component.ts

import { Component, OnDestroy, OnInit } from '@angular/core';
import { BehaviorSubject, takeUntil } from 'rxjs';
import { SentenceBuilderService } from '../services/sentence-builder.service';

interface IWordValue {
  name: string;
  id: number;
}

export interface IData {
  name: string;
  value: IWordValue[];
}

export interface ISentence {
  expression: string;
  id?: number;
}

@Component({
  selector: 'app-sentence-builder',
  templateUrl: './sentence-builder.component.html',
  styleUrls: ['./sentence-builder.component.scss'],
})
export class SentenceBuilderComponent implements OnInit, OnDestroy {
  private isLoadingSubject = new BehaviorSubject(false);
  isLoading$ = this.isLoadingSubject.asObservable();

  selectedWords: string[] = [];
  savedSentences: ISentence[] = [];

  constructor(
    private readonly sentenceBuilderService: SentenceBuilderService
  ) {}

  ngOnInit(): void {
    this.isLoadingSubject.next(true);
    this.sentenceBuilderService.getAllWords().subscribe((data) => {
      this.wordDataNew = Object.keys(data).map((x: any) => {
        return { name: x, value: data[x] };
      });
      this.isLoadingSubject.next(false);
    });

    this.sentenceBuilderService.getAllSentences().subscribe((data) => {
      this.savedSentences = data;
      this.isLoadingSubject.next(false);
    });
  }

  wordDataNew: IData[] = [];

  generatedSentence: string = '';

  buildSentence() {}

  selectedValue(e: any) {
    this.selectedWords.push(e.value);
    this.generatedSentence = this.selectedWords.join(' ');
  }

  submitSentence() {
    this.isLoadingSubject.next(true);
    this.sentenceBuilderService
      .saveWord({ expression: this.generatedSentence } as ISentence)
      .subscribe((c) => {
        this.savedSentences.push({
          expression: this.generatedSentence,
        } as ISentence);
        this.isLoadingSubject.next(false);
        this.generatedSentence = '';
        this.selectedWords = [];
      });
  }

  ngOnDestroy() {
    this.isLoadingSubject.complete();
  }
}
