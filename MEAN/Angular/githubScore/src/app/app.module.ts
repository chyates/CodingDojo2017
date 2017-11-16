import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { GhScoreService } from './gh-score.service';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule
  ],
  providers: [GhScoreService],
  bootstrap: [AppComponent]
})
export class AppModule { }
