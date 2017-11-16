import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  productList;
  productCreate;

  list() {
    this.productList = true;
  }

  create(){
    this.productCreate = true;
    this.productList = false;
    
  }

  reset(){
    this.productList = false;
    this.productCreate = false;
  }
}
