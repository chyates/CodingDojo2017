import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { ListingAllComponent } from './listing-all/listing-all.component';
import { ListingCreateComponent } from './listing-create/listing-create.component';
import { ListingUpdateComponent } from './listing-update/listing-update.component';
import { UserContactComponent } from './user-contact/user-contact.component';
import { UserComponent } from './user/user.component';
import { ListingApiService } from './listing-api.service';

@NgModule({
  declarations: [
    AppComponent,
    ListingAllComponent,
    ListingCreateComponent,
    ListingUpdateComponent,
    UserContactComponent,
    UserComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule,
    FormsModule
  ],
  providers: [ListingApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
