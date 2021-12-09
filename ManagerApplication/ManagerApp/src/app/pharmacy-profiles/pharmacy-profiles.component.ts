import { Component, OnInit } from '@angular/core';
import { IApiKey } from '../model/apikey';
import { PharmacyProfileService } from '../services/pharmacy-profile.service';

@Component({
  selector: 'app-pharmacy-profiles',
  templateUrl: './pharmacy-profiles.component.html',
  styleUrls: ['./pharmacy-profiles.component.css']
})
export class PharmacyProfilesComponent implements OnInit {
  pharmacies : IApiKey[] = [];
  constructor(private _pharmacyProfileService : PharmacyProfileService) { }

  ngOnInit(): void {
    this._pharmacyProfileService.getAllPharmacies().subscribe(
      pharmacies => {
        this.pharmacies = pharmacies.sort((a, b) => (a.id > b.id ? 1 : -1));
      });
  }

}
