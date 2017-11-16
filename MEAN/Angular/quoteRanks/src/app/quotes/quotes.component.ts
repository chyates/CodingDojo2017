import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Quote } from '../quote';

@Component({
  selector: 'app-quotes',
  templateUrl: './quotes.component.html',
  styleUrls: ['./quotes.component.css']
})
export class QuotesComponent implements OnInit {

  constructor() { }
  @Input() content;
  @Input() author;
  @Input() rating;
  @Input() index;

  @Output() voteUp = new EventEmitter();
  @Output() voteDown = new EventEmitter();

  ngOnInit() {
  }

  upvote(event, index){
    this.voteUp.emit(index);
  }

  downvote(event, index){
    this.voteDown.emit(index);
  }

}
