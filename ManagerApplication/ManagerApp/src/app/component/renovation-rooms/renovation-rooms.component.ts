import { Component, NgModule, OnInit } from '@angular/core';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';

@Component({
  selector: 'app-renovation-rooms',
  templateUrl: './renovation-rooms.component.html',
  styleUrls: ['./renovation-rooms.component.css']
})
export class RenovationRoomsComponent implements OnInit {
    
    selectedType: string = '';
    isMerged: boolean = false;
    allRooms: any;
    errorMessage: Boolean = true;
    firstRoom: number;
    secondRoom: number;
    divideRoom: number;
    selectedDate: any;
    step3: Boolean = false;

    constructor(private hospitalMapService: HospitalMapService) {
    }

    ngOnInit(): void {
      this.hospitalMapService.getRooms().subscribe(roomsFromBack =>{
        this.allRooms = roomsFromBack;
      }); 

      this.selectedDate = new Date()
    }

    onSubmit(): void {
      this.step1Disable();
      this.isMerged = true;
    }

    onSubmit1(): void {
      let select2 = document.getElementById('select2') as HTMLSelectElement;
      this.firstRoom = parseInt(select2.value);
      let select3 = document.getElementById('select3') as HTMLSelectElement;
      this.secondRoom = parseInt(select3.value);
       
      this.hospitalMapService.IsFirstRoomNextToSecond(this.firstRoom, this.secondRoom).subscribe(ret => {
        this.errorMessage = ret;
        
        if(this.errorMessage === true) {
          let select2 = document.getElementById('select2') as HTMLSelectElement;
          select2.disabled = true;
          let select3 = document.getElementById('select3') as HTMLSelectElement;
          select3.disabled = true;
          let next2 = document.getElementById('next2') as HTMLButtonElement;
          next2.disabled = true;
          let back1 = document.getElementById('back1') as HTMLButtonElement;
          back1.disabled = true;

          this.step3 = true;
        } 
      })

      

    }

    onSubmit2(): void {
      let select4 = document.getElementById('select4') as HTMLSelectElement;
      this.divideRoom = parseInt(select4.value);
      select4.disabled = true;
      let next2 = document.getElementById('next2') as HTMLButtonElement;
      next2.disabled = true;
      let back1 = document.getElementById('back1') as HTMLButtonElement;
      back1.disabled = true;

      this.step3 = true;
    }

    onSubmit3(): void {
      let next3 = document.getElementById('next3') as HTMLButtonElement;
      next3.disabled = true;
      let back2 = document.getElementById('back2') as HTMLButtonElement;
      back2.disabled = true;
      let datepicker = document.getElementById('date') as HTMLButtonElement;
      datepicker.disabled = true;
      
    }

    back2(): void {
      let next2 = document.getElementById('next2') as HTMLButtonElement;
      next2.disabled = false;
      let back1 = document.getElementById('back1') as HTMLButtonElement;
      back1.disabled = false;

      if(this.selectedType == 'Merge'){
        let select2 = document.getElementById('select2') as HTMLSelectElement;
        select2.disabled = false;
        let select3 = document.getElementById('select3') as HTMLSelectElement;
        select3.disabled = false;
      } else {
        let select4 = document.getElementById('select4') as HTMLSelectElement;
        select4.disabled = false;
      }    

      this.selectedDate = new Date()
      this.step3 = false;
    }

    back1(): void {
      let next1 = document.getElementById('next1') as HTMLButtonElement;
      next1.disabled = false;
      let select1 = document.getElementById('select1') as HTMLSelectElement;
      select1.disabled = false;

      this.selectedType = ''
    }

    step1Disable() : void {
      let next1 = document.getElementById('next1') as HTMLButtonElement;
      next1.disabled = true;
      let select1 = document.getElementById('select1') as HTMLSelectElement;
      select1.disabled = true;
  
      this.selectedType = select1.value;
    }
}