import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  clicked = false;

  clickSwitch(click){
    if (click === 'click'){
      this.clicked = true;
    }
    else if (click === 'unclick'){
      this.clicked = false;
    }
  }
}
