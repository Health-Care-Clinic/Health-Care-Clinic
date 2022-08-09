import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DoctorsService } from 'src/app/services/doctors.service';
import { OnCallShiftService } from 'src/app/services/on-call-shift.service';

@Component({
  selector: 'app-workload',
  templateUrl: './workload.component.html',
  styleUrls: ['./workload.component.css']
})
export class WorkloadComponent implements OnInit {

  DoctorId: Number;
  constructor(private _route: ActivatedRoute, private doctorService: DoctorsService, private onCallShiftService: OnCallShiftService) { }
  todayTruly: Date;
  today: Date;
  monthYear: String;
  numOfPat:number;
  numOfOnc: number;
  numOfApp: number;
  numOfPatSize:string;
  numOfOncSize: string;
  numOfAppSize: string;
  
  ngOnInit(): void {
    this.DoctorId = +this._route.snapshot.paramMap.get('ido');  
    this.today = new Date();
    this.todayTruly = new Date(); 
    this.doctorService.getNumOfAppointments(Number(this.DoctorId),this.today.getMonth()+1,this.today.getFullYear()).subscribe(ret => {
      this.numOfApp = ret;
      this.numOfAppSize = (this.numOfApp * 4).toString()+'px';
    })
    this.doctorService.getNumOfPatients(Number(this.DoctorId),this.today.getMonth()+1,this.today.getFullYear()).subscribe(ret => {
      this.numOfPat = ret;
      this.numOfPatSize = (this.numOfPat * 4).toString()+'px';
    })
    this.onCallShiftService.getNumOfOnCallShift(Number(this.DoctorId),this.today.getMonth()+1,this.today.getFullYear()).subscribe(ret => {
      this.numOfOnc = ret;
      this.numOfOncSize = (this.numOfOnc * 4).toString()+'px';
    })
    this.monthYear = this.today.getFullYear()+'-'+(this.today.getMonth()+1);

   

    
    
  }

  next(){
    if(this.today.getMonth()<11){
      this.today = new Date(this.today.getFullYear(), this.today.getMonth()+1,1);}
    else{
      this.today = new Date(this.today.getFullYear()+1, 0,1);
    }
    this.doctorService.getNumOfAppointments(Number(this.DoctorId),this.today.getMonth()+1,this.today.getFullYear()).subscribe(ret => {
      this.numOfApp = ret;
      this.numOfAppSize = (this.numOfApp * 4).toString()+'px';
    })
    this.doctorService.getNumOfPatients(Number(this.DoctorId),this.today.getMonth()+1,this.today.getFullYear()).subscribe(ret => {
      this.numOfPat = ret;
      this.numOfPatSize = (this.numOfPat * 4).toString()+'px';
    })
    this.onCallShiftService.getNumOfOnCallShift(Number(this.DoctorId),this.today.getMonth()+1,this.today.getFullYear()).subscribe(ret => {
      this.numOfOnc = ret;
      this.numOfOncSize = (this.numOfOnc * 4).toString()+'px';
    })
    this.monthYear = this.today.getFullYear()+'-'+(this.today.getMonth()+1);

  }
  prev(){
    if(this.today.getMonth()!=0){
      this.today = new Date(this.today.getFullYear(), this.today.getMonth()-1,1);}
    else{
      this.today = new Date(this.today.getFullYear()-1, 11,1);
    }
    this.doctorService.getNumOfAppointments(Number(this.DoctorId),this.today.getMonth()+1,this.today.getFullYear()).subscribe(ret => {
      this.numOfApp = ret;
      this.numOfAppSize = (this.numOfApp * 4).toString()+'px';
    })
    this.doctorService.getNumOfPatients(Number(this.DoctorId),this.today.getMonth()+1,this.today.getFullYear()).subscribe(ret => {
      this.numOfPat = ret;
      this.numOfPatSize = (this.numOfPat * 4).toString()+'px';
    })
    this.onCallShiftService.getNumOfOnCallShift(Number(this.DoctorId),this.today.getMonth()+1,this.today.getFullYear()).subscribe(ret => {
      this.numOfOnc = ret;
      this.numOfOncSize = (this.numOfOnc * 4).toString()+'px';
    })
    this.monthYear = this.today.getFullYear()+'-'+(this.today.getMonth()+1);
  }

}
