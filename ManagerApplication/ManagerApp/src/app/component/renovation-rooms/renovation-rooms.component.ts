import { Component, NgModule, OnInit } from '@angular/core';
import { Equipment } from 'src/app/model/equipment';
import { Renovation, TypeOfRenovation } from 'src/app/model/renovation';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';
import { RenovationService } from 'src/app/services/renovation.service';

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
    selectedEndDate: any;
    step1: Boolean = false;
    step2: Boolean = false;
    step3: Boolean = false;
    step4: Boolean = false;
    step5: Boolean = false;
    duration: number = 1;
    newName: string = '';
    newType: any;
    newDescription: string = '';
    freeTerms: Array<Date>;
    date:Date;
    radioInput: any;
    showTerms:boolean;

    constructor(private hospitalMapService: HospitalMapService, private renovationService: RenovationService) {
    }

    ngOnInit(): void {
      this.date = new Date();
      this.showTerms = false;
      this.freeTerms = new Array<Date>();
      this.hospitalMapService.getRooms().subscribe(roomsFromBack =>{
        this.allRooms = roomsFromBack;
      }); 

      this.selectedEndDate = new Date();
      this.step1 = true;
      this.renovationService.getAllRenovations().subscribe(ret => {

      })
    }

    onSubmit(): void {
      this.step1Disable();
      this.isMerged = true;
      this.step2 = true;
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
      this.date = new Date(datepicker.value);
      datepicker.disabled = true;
      this.step4 = true;
    }

    onSubmit4(): void {
      let combo = document.getElementById('select5') as HTMLButtonElement;
      this.duration = parseInt(combo.value);

      let next4 = document.getElementById('next4') as HTMLButtonElement;
      next4.disabled = true;
      let back3 = document.getElementById('back3') as HTMLButtonElement;
      back3.disabled = true;
      let select5 = document.getElementById('select5') as HTMLButtonElement;
      select5.disabled = true;
      
      if(this.selectedType == 'Divide'){
        this.step5 = true;
      }
      else {
        let renovation = new Renovation(0,this.firstRoom,this.secondRoom,TypeOfRenovation.Merge,this.date,this.duration);
        this.renovationService.getFreeTermsForMerge(renovation).subscribe(ret =>{
          this.freeTerms = ret;
          this.showTerms = true;
        })
      }
    }

    onSubmit5(): void {
      let type = document.getElementById('select6') as HTMLButtonElement;
      this.newType = type.value;

      let next5 = document.getElementById('next5') as HTMLButtonElement;
      next5.disabled = true;
      let back4 = document.getElementById('back4') as HTMLButtonElement;
      back4.disabled = true;

      let nameLabel = document.getElementById('nameLabel') as HTMLButtonElement;
      nameLabel.disabled = true;
      let typeLabel = document.getElementById('typeLabel') as HTMLButtonElement;
      typeLabel.disabled = true;
      let descriptionLabel = document.getElementById('descriptionLabel') as HTMLButtonElement;
      descriptionLabel.disabled = true;
      let newName = document.getElementById('newName') as HTMLButtonElement;
      newName.disabled = true;
      let newType = document.getElementById('select6') as HTMLButtonElement;
      newType.disabled = true;
      let duration = document.getElementById('newDescription') as HTMLButtonElement;
      duration.disabled = true;

      let renovation = new Renovation(0,this.divideRoom,0,TypeOfRenovation.Divide,this.date,this.duration);
      this.renovationService.getFreeTermsForDivide(renovation).subscribe(ret => {
        this.freeTerms = ret;
        this.showTerms = true;
      })
    }

    onFinish(): void{
      if(!this.radioInput){
        alert('You must select date and time!');
        return;
      }

      let term = this.freeTerms[this.radioInput]
      this.showTerms = false;
      this.step5 = false;
      this.step4 = false;
      this.step3 = false;
      this.step2 = false;

      if (this.selectedType === 'Merge') {
        this.renovationService.getAllRenovations().subscribe(ret => {
          let newId = 0;
          for (let r of ret) {
            if (r.id > newId) {
              newId = r.id;
            }
          }
          //let date = new Date(2021, 10, 5, 10, 0, 0)
          let renovation = new Renovation(newId + 1, this.firstRoom, this.secondRoom, TypeOfRenovation.Merge, term,this.duration);
          this.renovationService.addRenovation(renovation).subscribe(ret =>{

          })
        })
        
        
      }

      let select1 = document.getElementById('select1') as HTMLButtonElement;
      select1.disabled = false;
      let next1 = document.getElementById('next1') as HTMLButtonElement;
      next1.disabled = false;
    }

    backFromFinish(): void{
      if(this.selectedType == 'Divide'){
        let next5 = document.getElementById('next5') as HTMLButtonElement;
      next5.disabled = false;
      let back4 = document.getElementById('back4') as HTMLButtonElement;
      back4.disabled = false;

      let nameLabel = document.getElementById('nameLabel') as HTMLButtonElement;
      nameLabel.disabled = false;
      let typeLabel = document.getElementById('typeLabel') as HTMLButtonElement;
      typeLabel.disabled = false;
      let descriptionLabel = document.getElementById('descriptionLabel') as HTMLButtonElement;
      descriptionLabel.disabled = false;
      let newName = document.getElementById('newName') as HTMLButtonElement;
      newName.disabled = false;
      let newType = document.getElementById('select6') as HTMLButtonElement;
      newType.disabled = false;
      let newDescription = document.getElementById('newDescription') as HTMLButtonElement;
      newDescription.disabled = false;
        this.showTerms = false;
      }
      else{
        let next4 = document.getElementById('next4') as HTMLButtonElement;
      next4.disabled = false;
      let back3 = document.getElementById('back3') as HTMLButtonElement;
      back3.disabled = false;
      let select5 = document.getElementById('select5') as HTMLButtonElement;
      select5.disabled = false;
      this.showTerms = false;
      }
    }

    back4(): void {
      this.step5 = false;

      let next4 = document.getElementById('next4') as HTMLButtonElement;
      next4.disabled = false;
      let back3 = document.getElementById('back3') as HTMLButtonElement;
      back3.disabled = false;
      let select5 = document.getElementById('select5') as HTMLButtonElement;
      select5.disabled = false;

      this.newName = '';
      this.newType = 'RoomForAppointments';
      this.newDescription = '';
    }

    back3(): void {
      let next3 = document.getElementById('next3') as HTMLButtonElement;
      next3.disabled = false;
      let back2 = document.getElementById('back2') as HTMLButtonElement;
      back2.disabled = false;
      let datepicker = document.getElementById('date') as HTMLButtonElement;
      datepicker.disabled = false;
      this.duration = 1;

      this.step4 = false;
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

      this.selectedEndDate = new Date()
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