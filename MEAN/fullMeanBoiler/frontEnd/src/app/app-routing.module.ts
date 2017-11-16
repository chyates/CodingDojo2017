import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { PlayerListComponent } from './player-list/player-list.component';
import { PlayerAddComponent } from './player-add/player-add.component';
import { GameComponent } from './game/game.component';

const routes: Routes = [
  // { path: '', pathMatch: 'full', component: AppComponent },
  { path: 'players', component: PlayerListComponent},
  { path: 'players/add', component: PlayerAddComponent },
  { path: 'games', component: GameComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
