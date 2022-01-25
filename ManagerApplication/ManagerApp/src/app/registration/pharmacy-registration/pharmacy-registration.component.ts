import { ReturnStatement, TypeScriptEmitter } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { IApiKey } from 'src/app/model/apikey';
import { RegistrationService } from 'src/app/services/registration.service';

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
  public apikey: IApiKey = {id: 0, name: "", key: "", baseUrl: "", city: "", category: "", imagePath: "", note: "", image:""};
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
      alert(this.errorText)
      return;
    }
    if(!this.isValidUrl(this.url)){
      this.errorText = "Please enter valid URL."
      this.isErrorLabelVisible = true;
      alert(this.errorText)
      return;
    }
  
    this.errorText = ""
    this.isErrorLabelVisible = false;
    this.apikey.name = this.name;
    this.apikey.baseUrl = this.url;
    this.apikey.category = "Pharmacy";
    this._registrationService.registerPharmacy(this.apikey).subscribe(res => {this.name = ""; this.url = "";
    alert("Sucessfully registrated.")}, error => {
        this.errorText = "Unsuccesful registration.";
        alert(this.errorText)
        this.isErrorLabelVisible = true;}
      );
  
  }

  isValidUrl(inputUrl: string): boolean {
    let pattern = new RegExp('(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}', 'i'); //preciznije?
    return pattern.test(inputUrl);
  }

}
