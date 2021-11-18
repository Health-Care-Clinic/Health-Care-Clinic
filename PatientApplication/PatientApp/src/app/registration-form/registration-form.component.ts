import { Component, OnInit } from '@angular/core';
import { PatientService } from '../patient/patient.service';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

  constructor(public service: PatientService) { }

  ngOnInit(): void {
  }

}
