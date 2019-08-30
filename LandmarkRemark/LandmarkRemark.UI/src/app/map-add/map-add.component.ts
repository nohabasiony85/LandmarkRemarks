import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormControl, FormGroup } from "@angular/forms";
import { LandmarkService } from "../services/landmark-service.service";
import { UserLocation } from "../shared/user-location";
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-map-add',
  templateUrl: './map-add.component.html',
  styleUrls: ['./map-add.component.css'],
  providers: [LandmarkService],
})
export class MapAddComponent implements OnInit {

  newLocation: UserLocation;
  locationForm = new FormGroup({
    username: new FormControl(),
    notes: new FormControl()
  });

  constructor( @Inject(MAT_DIALOG_DATA) public myLocation: UserLocation, public dialogRef: MatDialogRef<MapAddComponent>, public landmarkService: LandmarkService) { }

  ngOnInit() {
  }

  cancel() {
    this.dialogRef.close();
  }

  onSubmit() {
    const formModel = this.locationForm.value;

    this.newLocation = new UserLocation();

    this.newLocation.latitude = this.myLocation.latitude;
    this.newLocation.longitude = this.myLocation.longitude;
    this.newLocation.notes = formModel.notes;
    this.newLocation.userId = formModel.username;

    this.landmarkService.addLocation(this.newLocation)
      .subscribe(
      locations => {
        console.log('User locations saved', locations);
        this.dialogRef.close(locations);
      });
  }
}
