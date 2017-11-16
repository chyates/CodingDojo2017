import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListingUpdateComponent } from './listing-update.component';

describe('ListingUpdateComponent', () => {
  let component: ListingUpdateComponent;
  let fixture: ComponentFixture<ListingUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListingUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListingUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
