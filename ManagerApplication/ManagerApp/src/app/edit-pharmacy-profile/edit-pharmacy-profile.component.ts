import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { IApiKey } from '../model/apikey';
import { PharmacyProfileService } from '../services/pharmacy-profile.service';

@Component({
  selector: 'app-edit-pharmacy-profile',
  templateUrl: './edit-pharmacy-profile.component.html',
  styleUrls: ['./edit-pharmacy-profile.component.css']
})
export class EditPharmacyProfileComponent implements OnInit {
  public idp: number = -1;
  public pharmacy : IApiKey = {id: 0, name: "", key: "", baseUrl: "", city: "", category: "", imagePath: "", note: "", image: ""};
  @Output() public onUploadFinished = new EventEmitter();
  public message: string = "";

  constructor(private _route: ActivatedRoute, private _pharmacyProfileService : PharmacyProfileService, private _router: Router, private _http: HttpClient) { }

  ngOnInit(): void {
    this.idp = +this._route.snapshot.paramMap.get('idp');
    this._pharmacyProfileService.getPharmacy(this.idp).subscribe( pharmacy => { this.pharmacy = pharmacy; 
      });
  }

  editPharmacyProfile(files): void {
    this._pharmacyProfileService.editPharmacyProfile(this.pharmacy).subscribe(res => {
      this.uploadFile(files)
      this._router.navigate(['pharmacy-profiles']);
    });
  }
  cancel(): void {
    this._router.navigate(['pharmacy-profiles']);
  }

  uploadFile = (files) => {
    if(files.length === 0 || this.pharmacy.imagePath === ""){
      return;
    }

    let imageToUpload = <File>files[0];
    this.pharmacy.imagePath = imageToUpload.name;
    const formData = new FormData();
    formData.append('file', imageToUpload, imageToUpload.name);
    this._http.post("http://localhost:65508/hospital/pharmacyimage/upload-image/" + this.idp, formData, {reportProgress: false, observe: 'events'}).subscribe(event =>{
      if(event.type === HttpEventType.Response){
        this.onUploadFinished.emit(event.body);
      }
    })
  }

  


}
