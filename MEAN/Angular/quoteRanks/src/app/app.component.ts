import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Quote } from './quote';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Quote Homepage';
  quote = new Quote();
  quotes: Array<Quote> = [];

  addQuote(){
    this.quotes.push(this.quote);
    console.log(this.quote);
    this.quote = new Quote();
  }
  upRating(index){
    this.quotes[index].rating += 1;
  }

  downRating(index){
    this.quotes[index].rating -= 1;
  }

}
