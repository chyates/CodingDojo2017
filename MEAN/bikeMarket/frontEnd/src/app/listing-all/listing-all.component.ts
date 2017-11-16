import { Component, OnInit } from '@angular/core';
import { ListingApiService } from '../listing-api.service';
import { Router } from '@angular/router'

@Component({
  selector: 'app-listing-all',
  templateUrl: './listing-all.component.html',
  styleUrls: ['./listing-all.component.css']
})
export class ListingAllComponent implements OnInit {

  constructor (
    private _listingApi: ListingApiService,
    private _router: Router ) { }

    allListings = [];

  ngOnInit() {
    this._listingApi.allListings()
      .then(data => this.allListings = data.results)
      console.log(this.allListings);
  }

  
}
