import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IApiKey } from '../model/apikey';
import { PharmacyProfileService } from '../services/pharmacy-profile.service';

@Component({
  selector: 'app-edit-pharmacy-profile',
  templateUrl: './edit-pharmacy-profile.component.html',
  styleUrls: ['./edit-pharmacy-profile.component.css']
})
export class EditPharmacyProfileComponent implements OnInit {
  idp: number = -1;
  pharmacy : IApiKey = {id: 0, name: "", key: "", baseUrl: "", city: "", category: "", imagePath: "", note: ""};
  constructor(private _route: ActivatedRoute, private _pharmacyProfileService : PharmacyProfileService, private _router: Router) { }

  ngOnInit(): void {
    this.idp = +this._route.snapshot.paramMap.get('idp');
    this._pharmacyProfileService.getPharmacy(this.idp).subscribe( pharmacy => { this.pharmacy = pharmacy; });
  }

  editPharmacyProfile(): void {
    this._pharmacyProfileService.editPharmacyProfile(this.pharmacy).subscribe(res => {
      this._router.navigate(['pharmacy-profiles']);
    });
  }


}
