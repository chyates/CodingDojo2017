import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class GhScoreService {

  constructor(private _http: Http) { }

  retrieveUser(username){
    return this._http.get(`https://api.github.com/users/${username}`)
    .map(user => user.json())
    .toPromise();
  }

  // calculateScore(user){
  //   var score: number = 0;
  //   if (this.user.followers){
  //     score += this.user.followers; 
  //   }
  //   if (this.user.public_repos){
  //     score += this.user.public_repos
  //   }
  //   return score;
  // }

}
