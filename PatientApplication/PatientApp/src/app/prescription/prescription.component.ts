import { Component, OnInit } from '@angular/core';
import { IPrescription } from './IPrescription';
import { PatientService } from '../patient/patient.service';
@Component({
  selector: 'app-prescription',
  templateUrl: './prescription.component.html',
  styleUrls: ['./prescription.component.css']
})
export class PrescriptionComponent implements OnInit {

  prescription : IPrescription = 
  {
    date : new Date(),
    doctor : {
      id: 0,
      name : '',
      surname: ''
    },
    diagnosis: '',
    medicine : '',
    quantity : 0
  }
  show : boolean = false;
  displayedColumns: string[] = ['date', 'doctor', 'medicine'];

allPrescriptions : IPrescription[] = [];
  errorMessage: any;
  constructor(private _patientService : PatientService) { }

  ngOnInit(): void {
    this.getAllPrescriptions();
  }

  showPrescriptionInfo(prescription : IPrescription)
  {
    this.show = true;
    this.prescription = prescription;
  }

  getAllPrescriptions()
  {
    this._patientService.getAllPrescriptionsForPatient()
    .subscribe(data => this.allPrescriptions = data,
                error => this.errorMessage = <any>error);
  }

}
