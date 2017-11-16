import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  colors = [];
  createHex(){
    var hexOptions = [0,1,2,3,4,5,6,7,8,9,'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E', 'f', 'F'];
    var hexCode = "#";
    
    for (var i=0; i<6; i++){
      // console.log(i);
      hexCode += hexOptions[Math.floor(Math.random()*hexOptions.length)];
    }
    return hexCode;
  }
  ngOnInit() {
    for(let j=0; j<10; j++){
      this.colors[j] = this.createHex();
    }
  }
}
