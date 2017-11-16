import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [
  // { path: '', pathMatch: 'full', component: AppComponent },
  { path: 'products', component: AppComponent, children: [
    { path: 'new', component: AppComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


// <a (click)="reset()" [routerLink]="['']">Home</a> | 