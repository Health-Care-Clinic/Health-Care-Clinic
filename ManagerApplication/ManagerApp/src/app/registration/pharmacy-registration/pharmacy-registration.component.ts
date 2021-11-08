import { ReturnStatement, TypeScriptEmitter } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { RegistrationService } from 'src/app/services/registration.service';
import { IApiKey } from './apikey';

@Component({
  selector: 'registration',
  templateUrl: './pharmacy-registration.component.html',
  styleUrls: ['./pharmacy-registration.component.css'],
  providers: [ RegistrationService ]
})
export class PharmacyRegistrationComponent implements OnInit {

  public isErrorLabelVisible: boolean;
  public errorText: string;
  public labelVisible: boolean = false;
  public name: string = "";
  public apikey: IApiKey = { Name: "", Key: "", BaseUrl: "", Category: ""};
  public url: string = "";

  constructor(private _registrationService : RegistrationService) {
    this.isErrorLabelVisible = true;
    this.errorText = "no error";
    this.apikey
  }

  ngOnInit(): void {
  }

  register(): void {
    this.labelVisible = true;
    if(this.name == "" || this.url == ""){
      this.errorText = "Please fill out all fields."
      this.isErrorLabelVisible = true;
      return;
    }
    if(!this.isValidUrl(this.url)){
      this.errorText = "Please enter valid URL."
      this.isErrorLabelVisible = true;
      return;
    }
  
    this.errorText = ""
    this.isErrorLabelVisible = false;
    this.apikey.Name = this.name;
    this.apikey.BaseUrl = this.url;
    this.apikey.Category = "Pharmacy";
    this._registrationService.registerPharmacy(this.apikey).subscribe(res => {this.name = ""; this.url = "";}, error => {
        this.errorText = "Unsuccesful registration.";
        this.isErrorLabelVisible = true;}
      );
  
  }

  isValidUrl(inputUrl: string): boolean {
    let pattern = new RegExp('(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}', 'i'); //preciznije?
    /*'^(https?:\\/\\/)?'+ // protocol
      '((([a-z\\d]([a-z\\d-]*[a-z\\d])*)\\.)+[a-z]{2,}|'+ // domain name
      '((\\d{1,3}\\.){3}\\d{1,3}))'+ // OR ip (v4) address
      '(\\:\\d+)?(\\/[-a-z\\d%_.~+]*)*'+ // port and path
      '(\\?[;&a-z\\d%_.~+=-]*)?'+ // query string
      '(\\#[-a-z\\d_]*)?$','i');*/ // fragment locator
    return pattern.test(inputUrl);
  }

}
