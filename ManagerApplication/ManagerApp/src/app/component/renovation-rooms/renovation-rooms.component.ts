import { Component, OnInit } from '@angular/core';
import { Transfer } from 'src/app/model/transfer';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';

@Component({
  selector: 'app-equipment-list',
  templateUrl: './renovation-rooms.component.html',
  styleUrls: ['./renovation-rooms.component.css']
})
export class RenovationRoomsComponent implements OnInit {
    
    selectedType: any;


    ngOnInit(): void {
        
       
       }

    onSubmit(): void {
      this.step1Disable();
    }

    step1Disable() : void {
      let next1 = document.getElementById('next1') as HTMLButtonElement;
      next1.disabled = true;
      let select1 = document.getElementById('select1') as HTMLSelectElement;
      select1.disabled = true;
  
      this.selectedType = select1.value;
    }
}