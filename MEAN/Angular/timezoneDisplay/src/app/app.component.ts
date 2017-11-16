import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  today;
  clicked = 'none'
  getDate(region) {
    if (region === 'CST'){
      this.today = Date.now();
    }
    else if (region === 'MST'){
      this.today = Date.now() - 3600000;
    }
    else if (region === 'PST'){
      this.today = Date.now() - (3600000 * 2);
    }
    else if (region === 'EST'){
      this.today = Date.now() + 3600000;
    }
    else{
      this.today = '';
    }
    this.clicked = region;
  }
}
