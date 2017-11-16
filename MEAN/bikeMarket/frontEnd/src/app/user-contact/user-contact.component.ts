import { Component, OnInit } from '@angular/core';
import { ListingApiService } from '../listing-api.service';

@Component({
  selector: 'app-user-contact',
  templateUrl: './user-contact.component.html',
  styleUrls: ['./user-contact.component.css']
})
export class UserContactComponent implements OnInit {

  constructor(private _listingApi: ListingApiService) { }

  ngOnInit() {
  }

}
