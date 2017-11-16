import { Component, OnInit } from '@angular/core';
import { ListingApiService } from '../listing-api.service';
import { Router } from '@angular/router'
import { Listing } from '../listing'

@Component({
  selector: 'app-listing-create',
  templateUrl: './listing-create.component.html',
  styleUrls: ['./listing-create.component.css']
})
export class ListingCreateComponent implements OnInit {

  constructor(
    private _listingApi: ListingApiService,
    private _router: Router) { }

    listing = new Listing();

  ngOnInit() {
  }

  addListing() {
    this._listingApi.createListing(this.listing)
    .then(data => this._router.navigateByUrl('/listings'));
    console.log(this.listing);
    this.listing = new Listing();
  }
}
