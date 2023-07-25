// src/app/sentence-builder/sentence-builder.component.ts

import { Component, OnDestroy, OnInit } from '@angular/core';
import { BehaviorSubject, takeUntil } from 'rxjs';
import { SentenceBuilderService } from '../services/sentence-builder.service';

@Component({
  selector: 'app-sentence-builder',
  templateUrl: './sentence-builder.component.html',
  styleUrls: ['./sentence-builder.component.scss'],
})
export class SentenceBuilderComponent implements OnInit, OnDestroy {
  private isLoadingSubject = new BehaviorSubject(false);
  isLoading$ = this.isLoadingSubject.asObservable();

  data: any[] = [];

  constructor(
    private readonly sentenceBuilderService: SentenceBuilderService
  ) {}

  ngOnInit(): void {
    this.isLoadingSubject.next(true);
    this.sentenceBuilderService.getAll().subscribe((data) => {
      this.data = data;
      this.isLoadingSubject.next(false);
    });
  }

  wordDataNew: any[] = [
    {
      name: 'nouns',
      value: ['cat', 'dog', 'house', 'car'],
    },
    {
      name: 'verbs',
      value: ['runs', 'jumps', 'eats', 'sleeps'],
    },
    {
      name: 'adjectives',
      value: ['big', 'small', 'happy', 'sad'],
    },
    {
      name: 'adverbs',
      value: ['quickly', 'slowly', 'happily', 'sadly'],
    },
    {
      name: 'Preposition',
      value: ['quickly', 'slowly', 'happily', 'sadly'],
    },
  ];

  wordData: any = {
    nouns: ['cat', 'dog', 'house', 'car'],
    verbs: ['runs', 'jumps', 'eats', 'sleeps'],
    adjectives: ['big', 'small', 'happy', 'sad'],
    adverbs: ['quickly', 'slowly', 'happily', 'sadly'],
  };

  nouns: string[] = this.wordData.nouns;
  verbs: string[] = this.wordData.verbs;
  adjectives: string[] = this.wordData.adjectives;
  adverbs: string[] = this.wordData.adverbs;

  selectedNoun: string = '';
  selectedVerb: string = '';
  selectedAdjective: string = '';
  selectedAdverb: string = '';

  generatedSentence: string = '';

  buildSentence() {
    this.generatedSentence =
      this.selectedAdverb +
      ' ' +
      this.selectedAdjective +
      ' ' +
      this.selectedNoun +
      ' ' +
      this.selectedVerb +
      '.';
  }

  ngOnDestroy() {
    this.isLoadingSubject.complete();
  }
}
