import { Component } from '@angular/core';
import { ListingApiService } from './listing-api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor (private _listingApi: ListingApiService){}
  // loggedIn = false;

  // ngOnInit(){
  //   console.log("in app component", this.loggedIn);
  // }
}
