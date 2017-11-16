import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ListingAllComponent } from './listing-all/listing-all.component';
import { ListingCreateComponent } from './listing-create/listing-create.component';
import { ListingUpdateComponent } from './listing-update/listing-update.component';
import { UserContactComponent } from './user-contact/user-contact.component';
import { UserComponent } from './user/user.component';


const routes: Routes = [
  // { path: '', pathMatch: 'full', component: AppComponent },
  { path: 'listings', component: ListingAllComponent},
  { path: 'register', component: UserComponent},
  { path: 'login', component: UserComponent},
  { path: 'listings/add', component: ListingCreateComponent },
  { path: 'logOff', component: UserComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
