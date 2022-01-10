import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
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
  constructor(private _pharmacyProfileService : PharmacyProfileService, private _router: Router, private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this._pharmacyProfileService.getAllPharmacies().subscribe(
      pharmacies => {
        this.pharmacies = pharmacies.sort((a, b) => (a.id > b.id ? 1 : -1));
        let i : number;
        for(i = 0; i < this.pharmacies.length; i++){
          if(this.pharmacies[i].imagePath != "" && this.pharmacies[i].imagePath != null){
            this.loadPharmacyImage(i);
          }
        }
      });
  }

  editPharmacyProfile(id: number): void {
    this._router.navigate(['edit-pharmacy-profile', id]);
  }

  showTenderStatistic(id: number): void {
    this._router.navigate(['pharmacy-tender-statistics', id]);
  }

  loadPharmacyImage(i: number): void {
    this._pharmacyProfileService.getPharmacyImage(this.pharmacies[i].imagePath).subscribe(
      result => {
        this.pharmacies[i].image = this.sanitizer.bypassSecurityTrustResourceUrl('data:image/jpg;base64,' + result);
      },
      error => {
        console.log(error);
      }
    );
  }

}
