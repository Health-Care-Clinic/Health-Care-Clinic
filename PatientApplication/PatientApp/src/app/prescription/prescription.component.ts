import { Component, Input, OnInit } from '@angular/core';
import { IPrescription } from './IPrescription';
import { PatientService } from '../patient/patient.service';
import { IAppointment } from '../service/IAppointment';
import { ObjectUnsubscribedError } from 'rxjs';
@Component({
  selector: 'app-prescription',
  templateUrl: './prescription.component.html',
  styleUrls: ['./prescription.component.css']
})
export class PrescriptionComponent implements OnInit {

  prescription : IPrescription = 
  {
    date: new Date(),
    doctor: {
      id: 0,
      name: '',
      surname: ''
    },
    diagnosis: '',
    medicine: '',
    quantity: 0,
    appointmetnId: 0
  }
  @Input() appointment !: IAppointment;
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
    let self = this
    this._patientService.getAllPrescriptionsForPatient()
    .subscribe(data =>{ this.allPrescriptions = data
      //if(this.appointment.id != 0 )
        //this.allPrescriptions = this.allPrescriptions.filter(p => p.appointmetnId.valueOf() === self.appointment.id.valueOf());
      //this.allPrescriptions = this.appointment.id != 0 ? this.allPrescriptions.filter(p => p.appointmetnId === self.appointment.id) : this.allPrescriptions
    },
         error => this.errorMessage = <any>error);
  }

}
