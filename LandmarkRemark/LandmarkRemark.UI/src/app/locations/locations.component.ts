import { Component, OnInit, NgZone} from '@angular/core';
import { LandmarkService } from "../services/landmark-service.service";
import { UserLocation } from "../shared/user-location";

import {MatDialog} from '@angular/material';
import { MapAddComponent } from "../map-add/map-add.component";

declare var google: any;

@Component({
  selector: 'app-locations',
  templateUrl: './locations.component.html',
  styleUrls: ['./locations.component.css'],
  providers: [LandmarkService],
})
export class LocationsComponent implements OnInit {

  loadingApi : boolean = false;
  isNavigating: boolean = false;

  title: string = 'Angular Map';
  lat: number = 0;
  lng: number = 0;
  zoom: number = 16;

  mapLocations: UserLocation[] = [];
  tableLocations: UserLocation[];

  locationToSave: UserLocation;

  filterString: string = '';

  myLocation: any = {
    latitude: 0,
    longitude: 0,
    address: '',
    label: '',
    iconUrl: './assets/home-map.png',
    notes: '',
    username: '',
    dateCreated:'',
    isHome: true
  };

  constructor(private landmarkService: LandmarkService, private _ngZone: NgZone, public dialog: MatDialog) {
  }

  ngOnInit() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(this.setPosition.bind(this));
    }

    this.loadUserlocations();
  }

  reCenter(){
    if (navigator.geolocation) {
      this.isNavigating = true;
      navigator.geolocation.getCurrentPosition(this.centerPosition.bind(this));
    }
  }

  centerPosition(position){
    this.lat = position.coords.latitude;
    this.lng = position.coords.longitude;
    this.isNavigating = false;
  }

  setPosition(position) {
    this.myLocation.latitude = position.coords.latitude;
    this.myLocation.longitude = position.coords.longitude;

    this.lat = position.coords.latitude;
    this.lng = position.coords.longitude;

    let geocoder = new google.maps.Geocoder();
    let latlng = new google.maps.LatLng(this.myLocation.latitude, this.myLocation.longitude);
    let request = { latLng: latlng };

    geocoder.geocode(request, (results, status) => {
      if (status == google.maps.GeocoderStatus.OK) {
        let result = results[0];
        if (result != null) {
          this._ngZone.run(() => {
            this.myLocation.address = result.formatted_address;
            this.mapLocations.push(this.myLocation);
          });
        } else {
          alert("Unable to find current address");
        }
      }
    });
  }

  loadUserlocations() {
    this.loadingApi = true;
    this.landmarkService.getLocations()
      .subscribe(
      locations => {
        this.loadingApi = false;
        this.tableLocations = locations;

        locations.forEach((item) => {
          this.mapLocations.push(item);
        });

      },
      err => {
        this.loadingApi = false;
        console.log(err);
      });
  }

  openDialog() {
    let dialogRef = this.dialog.open(MapAddComponent, {
      data: this.myLocation
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.mapLocations.push(result);
        this.tableLocations.push(result);
      }
    });
  }
}
