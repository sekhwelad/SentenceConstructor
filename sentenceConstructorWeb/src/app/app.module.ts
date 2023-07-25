import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SentenceBuilderComponent } from './sentence-builder/sentence-builder.component';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http';
import { SentenceBuilderService } from './services/sentence-builder.service';

@NgModule({
  declarations: [AppComponent, SentenceBuilderComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatSelectModule,
    MatButtonModule,
    HttpClientModule,
  ],
  providers: [SentenceBuilderService],
  bootstrap: [AppComponent],
})
export class AppModule {}
