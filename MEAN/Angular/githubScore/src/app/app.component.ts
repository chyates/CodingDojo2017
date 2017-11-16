import { Component } from '@angular/core';
import { GhScoreService } from './gh-score.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  existingUser;
  score;
  username;
  promise;

  constructor(private _ghScore: GhScoreService) { }

  calculateScore() {
    console.log(this.username);
    this.promise = this._ghScore.retrieveUser(this.username);
    // console.log(this.user);
    if (this.promise) {
      this.promise.then(user => {
        if (user.id) {
          this.existingUser = true;
          this.score = user.public_repos + user.followers;
        }
        else {
          this.existingUser = false;
          this.score = null;
        }
        console.log(user.id);
      })
      .catch((err) => {
        this.existingUser = false;
    });
    }
    else {
      this.existingUser = false;
    }
  }
}
