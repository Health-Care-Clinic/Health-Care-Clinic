import { Injectable } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor() { }

  form : FormGroup = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    dateOfBirth: new FormControl(null),
    email: new FormControl(''),
    username: new FormControl(''),
    password: new FormControl(''),
    rePassword: new FormControl('')

  })
}
