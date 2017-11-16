import { Component, OnInit } from '@angular/core';
import { ListingApiService } from '../listing-api.service';
import { Router } from '@angular/router'
import { User } from '../user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor (
    private _listingApi: ListingApiService,
    private _router: Router 
  ) { }

  user = new User();
  submitted = false;
  sample =[];
  currentUser;

  ngOnInit() {
  }

  register() {
    this._listingApi.createUser(this.user)
    .then(data => {
      if (data.loggedIn === true){
        this.user = new User();
        this.currentUser = data.user;
        this._router.navigateByUrl('/listings')
      } else {
        this.user = new User();
        console.log("registration failed")
      }
    });
  }

  login() {
    this._listingApi.findUser(this.user.email)
    .then(data => {
      if (data.loggedIn === true){
        this.user = new User();
        this.currentUser = data.user;
        this._router.navigateByUrl('/listings')
      } else {
        this.user = new User();
        console.log("login failed")
      }
    });
  }

  logOff(){
    this._listingApi.endSession()
  }

}
