import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class ListingApiService {

  constructor(private _http: Http) { }

  createUser(user){
    return this._http.post('/api/register', user)
    .map(response => response.json())
    .toPromise();
  }

  findUser(email){
    return this._http.get('/api/login', email)
    .map(response => response.json())
    .toPromise();
  }

  allListings(){
    return this._http.get('api/allListings')
    .map(response => response.json())
    .toPromise();
  }

  createListing(listing){
    return this._http.post('/api/add', listing)
    .map(response => response.json())
    .toPromise();
  }

  endSession(){
    
  }
}
