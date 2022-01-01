import { Component, OnInit } from '@angular/core';
import { ShiftsService } from '../../services/shifts.service';

@Component({
  selector: 'app-shifts',
  templateUrl: './shifts.component.html',
  styleUrls: ['./shifts.component.css']
})
export class ShiftsComponent implements OnInit {

  shifts: any;

  constructor(private shiftsService: ShiftsService) { }

  ngOnInit(): void {
    this.shiftsService.getAllShifts().subscribe(shiftsFromBack=>{
      this.shifts = shiftsFromBack;
    })
  }

}
