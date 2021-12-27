import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IDoctor } from 'src/app/model/patient/doctor';
import { DoctorsService } from 'src/app/services/doctors.service';

@Component({
  selector: 'app-doctors',
  templateUrl: './doctors.component.html',
  styleUrls: ['./doctors.component.css']
})
export class DoctorsComponent implements OnInit {

  constructor(private doctorService: DoctorsService,private _route: ActivatedRoute,private router: Router) { }

  doctors: Array<IDoctor>

  ngOnInit(): void {
    this.doctorService.getAllDoctors().subscribe(ret =>{
      this.doctors = ret;
    })
  }

}
