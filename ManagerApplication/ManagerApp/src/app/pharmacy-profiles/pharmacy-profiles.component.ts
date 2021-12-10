import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IApiKey } from '../model/apikey';
import { PharmacyProfileService } from '../services/pharmacy-profile.service';

@Component({
  selector: 'app-pharmacy-profiles',
  templateUrl: './pharmacy-profiles.component.html',
  styleUrls: ['./pharmacy-profiles.component.css']
})
export class PharmacyProfilesComponent implements OnInit {
  pharmacies : IApiKey[] = [];
  imageUrl: string = '/assets/images/noimage.jpg';
  constructor(private _pharmacyProfileService : PharmacyProfileService, private _router: Router) { }

  ngOnInit(): void {
    this._pharmacyProfileService.getAllPharmacies().subscribe(
      pharmacies => {
        this.pharmacies = pharmacies.sort((a, b) => (a.id > b.id ? 1 : -1));
      });
  }

  editPharmacyProfile(id: number): void {
    this._router.navigate(['edit-pharmacy-profile', id]);
  }

}
