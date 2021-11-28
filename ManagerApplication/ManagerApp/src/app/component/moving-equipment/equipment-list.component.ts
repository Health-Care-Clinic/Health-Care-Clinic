import { Component, OnInit } from '@angular/core';
import { Transfer } from 'src/app/model/transfer';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';

@Component({
  selector: 'app-equipment-list',
  templateUrl: './equipment-list.component.html',
  styleUrls: ['./equipment-list.component.css']
})
export class EquipmentListComponent implements OnInit {

  allEquipment: any;
  equipmentNames: any;
  selectedEquipment: any;
  roomsWithEquipment: any;
  selectedRoom: any;
  maxQuantity: any;
  selectedQuantity: any;
  roomsWithEquipmentDst: any;
  selectedRoomDst: any;
  allTransfers: any;
  selectedDate: any;
  selectedDuration: any;
  radioSelected: any;
  freeTerms: any;
  day: number;
  var: number;
  duration: number;
  radioInput: any;

  backButton1: any;
  backButton2: any;
  backButton3: any;
  backButton4: any;
  backButton5: any;

  constructor(private hospitalMapService: HospitalMapService) {
    this.hospitalMapService.getAllEquipment().subscribe(equipmentFromBack =>{
      this.allEquipment = equipmentFromBack;
      this.equipmentNames = []
      for (let e of this.allEquipment) {
        if (!this.equipmentNames.includes(e.name)){
          this.equipmentNames.push(e.name)
        }
      }
    });
    this.hospitalMapService.getTransfers().subscribe(transfersFromBack =>{
      this.allTransfers = transfersFromBack;
      this.freeTerms = []
    })
   }

  ngOnInit(): void {
    this.selectedDate = new Date()
    this.var = 0
    this.duration = 0 
    this.radioInput = -1;

    this.step2Disable();
    this.step3Disable();
    this.step4Disable();
    this.step5Disable();
    this.step6Disable();

    this.backButton1 = false;
    this.backButton2 = false;
    this.backButton3 = false;
    this.backButton4 = false;
    this.backButton5 = false;
   }

   onFinish(): void {
    if(this.backButton5){
      this.step5Enable();
      this.step6Disable();
    } else {

      if(this.radioInput == -1){
        return;
      }
      
      let id = this.returnKey() + 1
      let term = this.freeTerms[this.radioInput].toString().split(' ')
      let month = this.returnMonth(term[1])-1;
      let time = term[4].split(':')
      let date = new Date(term[3], month, term[2], time[0], time[1], time[2]);

      let transfer = new Transfer(id, this.selectedEquipment, parseInt(this.selectedQuantity), parseInt(this.selectedRoom), parseInt(this.selectedRoomDst), 
        date.toString(), parseInt(this.selectedDuration))
      
      this.freeTerms = [];
      this.backButton5 = false;
      this.radioInput = -1;
      this.step6Disable();
      this.step1Enable();

      this.hospitalMapService.addTransfer(transfer).subscribe(() =>  {}     
      )

    }

   }

  onSubmit() : void{
    this.step1Disable();
    this.step2Enable();

    this.roomsWithEquipment = []
    for (let e of this.allEquipment) {
      if (e.name === this.selectedEquipment){
        this.roomsWithEquipment.push(e)
      }
    }

    this.hospitalMapService.getTransfers().subscribe(transfersFromBack =>{
      this.allTransfers = transfersFromBack;
    })
  }

  onSubmit2() : void {
    if (this.backButton1) {
      this.step1Enable();
      this.step3Disable();
    } else {
      this.step3Enable();
    }

    this.step2Disable();
    this.backButton1 = false;

    this.maxQuantity = 1;
    for (let e of this.allEquipment) {
      if (e.roomId == this.selectedRoom){
        if (e.name == this.selectedEquipment) {
          this.maxQuantity = e.quantity;
          let select3 = document.getElementById('select3') as HTMLSelectElement;
          select3.value = this.maxQuantity;
          break;
        }
      }
    }
  }

  onSubmit3() : void {
    if (this.backButton2) {
      this.step2Enable();
      this.step4Disable();
    } else {
      this.step4Enable();
    }

    this.step3Disable();
    this.backButton2 = false;

    this.roomsWithEquipmentDst = []
    for (let e of this.allEquipment) {
      if (!(e.roomId == this.selectedRoom)){
        let found = false;
        for (let eq of this.roomsWithEquipmentDst) {
          if (eq.roomId == e.roomId) {
            found = true;
            break;
          }
        }
        if (!found) {
          this.roomsWithEquipmentDst.push(e)
        }
      }
    }
  }

  onSubmit4() : void {
    if (this.backButton3) {
      this.step3Enable();
      this.step5Disable();
    } else {
      this.step5Enable();
    }

    this.step4Disable();
    this.backButton3 = false;
  }

  onSubmit5(): void {
    if (this.backButton4) {
      this.step4Enable();
      this.step6Disable();

    } else {
      this.step5Disable();
      this.backButton4 = false;
      this.step6Enable();

      this.findFreeTerms();
    }
    
    this.step5Disable();
    this.backButton4 = false;

  }

  back1() : void {
    this.backButton1 = true;
  }

  back2() : void {
    this.backButton2 = true;
  }

  back3() : void {
    this.backButton3 = true;
  }

  back4() : void {
    this.backButton4 = true;
  }

  back5(): void {
    this.backButton5 = true;
  }

  step1Enable() : void {
    let next1 = document.getElementById('next1') as HTMLButtonElement;
    next1.disabled = false;
    let select1 = document.getElementById('select1') as HTMLSelectElement;
    select1.disabled = false;
  }

  step1Disable() : void {
    let next1 = document.getElementById('next1') as HTMLButtonElement;
    next1.disabled = true;
    let select1 = document.getElementById('select1') as HTMLSelectElement;
    select1.disabled = true;

    this.selectedEquipment = select1.value;
  }

  step2Enable() : void {
    let next2 = document.getElementById('next2') as HTMLButtonElement;
    next2.disabled = false;
    let back1 = document.getElementById('back1') as HTMLButtonElement;
    back1.disabled = false;
    let select2 = document.getElementById('select2') as HTMLSelectElement;
    select2.disabled = false;
  }

  step2Disable() : void {
    let next2 = document.getElementById('next2') as HTMLButtonElement;
    next2.disabled = true;
    let back1 = document.getElementById('back1') as HTMLButtonElement;
    back1.disabled = true;
    let select2 = document.getElementById('select2') as HTMLSelectElement;
    select2.disabled = true;

    this.selectedRoom = select2.value;
  }

  step3Enable() : void {
    let next3 = document.getElementById('next3') as HTMLButtonElement;
    next3.disabled = false;
    let back2 = document.getElementById('back2') as HTMLButtonElement;
    back2.disabled = false;
    let select3 = document.getElementById('select3') as HTMLSelectElement;
    select3.disabled = false;
  }

  step3Disable() : void {
    let next3 = document.getElementById('next3') as HTMLButtonElement;
    next3.disabled = true;
    let back2 = document.getElementById('back2') as HTMLButtonElement;
    back2.disabled = true;
    let select3 = document.getElementById('select3') as HTMLSelectElement;
    select3.disabled = true;

    this.selectedQuantity = select3.value;
  }

  step4Enable() : void {
    let next4 = document.getElementById('next4') as HTMLButtonElement;
    next4.disabled = false;
    let back3 = document.getElementById('back3') as HTMLButtonElement;
    back3.disabled = false;
    let select4 = document.getElementById('select4') as HTMLSelectElement;
    select4.disabled = false;
  }

  step4Disable() : void {
    let next4 = document.getElementById('next4') as HTMLButtonElement;
    next4.disabled = true;
    let back3 = document.getElementById('back3') as HTMLButtonElement;
    back3.disabled = true;
    let select4 = document.getElementById('select4') as HTMLSelectElement;
    select4.disabled = true;

    this.selectedRoomDst = select4.value;
  }

  step5Enable() : void {
    let next5 = document.getElementById('next5') as HTMLButtonElement;
    next5.disabled = false;
    let back4 = document.getElementById('back4') as HTMLButtonElement;
    back4.disabled = false;
    let select5 = document.getElementById('select5') as HTMLSelectElement;
    select5.disabled = false;
    let date = document.getElementById('date') as HTMLSelectElement;
    date.disabled = false;

    this.backButton5 = false;

    this.freeTerms = []
  }

  step5Disable() : void {
    let next5 = document.getElementById('next5') as HTMLButtonElement;
    next5.disabled = true;
    let back4 = document.getElementById('back4') as HTMLButtonElement;
    back4.disabled = true;
    let select5 = document.getElementById('select5') as HTMLSelectElement;
    select5.disabled = true;
    let date = document.getElementById('date') as HTMLSelectElement;
    date.disabled = true;

    this.selectedDuration = select5.value;

  }

  step6Enable(): void {
    let finish = document.getElementById('finish') as HTMLButtonElement;
    finish.disabled = false;
    let back5 = document.getElementById('back5') as HTMLButtonElement;
    back5.disabled = false;
    let table = document.getElementById('tableTransfer') as HTMLSelectElement;
    table.disabled = false;

    let dates = this.selectedDate.toString().split("-")
    this.day = parseInt(dates[2])
  }

  step6Disable(): void {
    let finish = document.getElementById('finish') as HTMLButtonElement;
    finish.disabled = true;
    let back5 = document.getElementById('back5') as HTMLButtonElement;
    back5.disabled = true;
    let table = document.getElementById('tableTransfer') as HTMLSelectElement;
    table.disabled = true;
  }

  addMinutes(date): Date {
    let date1 = new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes() + 15, 0); 
    return date1;
  }

  findFreeTerms(): void{
    let num = this.selectedDuration/15;
    let dates = this.selectedDate.toString().split("-")
    this.day = parseInt(dates[2]);
    
    let date = new Date(parseInt(dates[0]), dates[1] - 1, this.day, 8, 0, 0);
    
    if(num == 1){
      while(date.getHours() != 17){
      
        if(this.checkIsItPosibleToPushIntoList(num, date)){
          this.freeTerms.push(date);
        }
        
        if(this.var == 0)
          date = this.addMinutes(new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes(), 0));
        else 
          date = new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes() + this.duration, 0);
      }
    } else if(num == 2) {
      while(date.getHours() != 16 || date.getMinutes() != 45){
      
        if(this.checkIsItPosibleToPushIntoList(num, date)){
          this.freeTerms.push(date);
        }

        if(this.var == 0)
          date = this.addMinutes(new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes(), 0));
        else 
          date = new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes() + this.duration, 0);
      }
    } else if(num == 3) {
      while(date.getHours() != 16 || date.getMinutes() != 30){
      
        if(this.checkIsItPosibleToPushIntoList(num, date)){
          this.freeTerms.push(date);
        }

        if(this.var == 0)
          date = this.addMinutes(new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes(), 0));
        else 
          date = new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes() + this.duration, 0);
      }
    } else if(num == 4) {
      while(date.getHours() != 16 || date.getMinutes() != 15){
        
        if(this.checkIsItPosibleToPushIntoList(num, date)){
          this.freeTerms.push(date);
        }

        if(this.var == 0)
          date = this.addMinutes(new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes(), 0));
        else 
          date = new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes() + this.duration, 0);
      }
    } else if(num == 6) {
      while(date.getHours() != 15 || date.getMinutes() != 45){
      
        if(this.checkIsItPosibleToPushIntoList(num, date)){
          this.freeTerms.push(date);
        }

        if(this.var == 0)
          date = this.addMinutes(new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes(), 0));
        else 
          date = new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes() + this.duration, 0);
      }
    } else if(num == 8) {
      while(date.getHours() != 15 || date.getMinutes() != 15){
      
        if(this.checkIsItPosibleToPushIntoList(num, date)){
          this.freeTerms.push(date);
        }

        if(this.var == 0)
          date = this.addMinutes(new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes(), 0));
        else 
          date = new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes() + this.duration, 0);
      }
    } else if(num == 10) {
      while(date.getHours() != 14 || date.getMinutes() != 45){
      
        if(this.checkIsItPosibleToPushIntoList(num, date)){
          this.freeTerms.push(date);
        }

        if(this.var == 0)
          date = this.addMinutes(new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes(), 0));
        else 
          date = new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes() + this.duration, 0);
      }
    } else if(num == 12) {
      while(date.getHours() != 14 || date.getMinutes() != 15){
      
        if(this.checkIsItPosibleToPushIntoList(num, date)){
          this.freeTerms.push(date);
        }
        if(this.var == 0)
          date = this.addMinutes(new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes(), 0));
        else 
          date = new Date(date.getFullYear(), date.getMonth(), this.day, date.getHours(), date.getMinutes() + this.duration, 0);
        
      }
    }
  }

  checkIsItPosibleToPushIntoList(num, date): Boolean{

    for(let i=0; i<num; i++){
      if(this.checkIsTermFree(date)) {
        date = this.addMinutes(date);
        this.var = 0;
      } else {
        if(i == 0) {
          this.var = 1;
          this.duration = this.findDuration(date);
        }
        
        return false;
      }
    }

    return true;
  }

  checkIsTermFree(date): Boolean{
    
    for (let t of this.allTransfers) {
      
      let prom = t.date.toString().split(' ')
      let dates = prom[0].split('.');
      let time = prom[1].split(':');
      
      if(t.sourceRoomId == this.selectedRoom || t.destinationRoomId == this.selectedRoomDst || 
        t.sourceRoomId == this.selectedRoomDst || t.destinationRoomId == this.selectedRoom){
          
        if(parseInt(dates[1]) == (date.getMonth()+1) && parseInt(dates[0]) == this.day && parseInt(time[0]) == date.getHours() && 
            parseInt(time[1]) == date.getMinutes()){
          return false;
        }
      } 
    }

    return true;
  }

  findDuration(date): number{
    let dur = 0;
    for (let t of this.allTransfers) {
      let prom = t.date.toString().split(' ')
      let dates = prom[0].split('.');
      let time = prom[1].split(':');
      
      if(parseInt(dates[1]) == (date.getMonth()+1) && parseInt(dates[0]) == this.day && parseInt(time[0]) == date.getHours() && 
      parseInt(time[1]) == date.getMinutes()){
        dur = t.duration;
      } 
    }

    return dur;
  }
  
  returnMonth(month): number{
    if(month == 'Dec') {
      return 12;
    } else if (month == 'Nov') {
      return 11;
    } else if (month == 'Oct') {
      return 10;
    } else if (month == 'Sep') {
      return 9;
    } else if (month == 'Aug') {
      return 8;
    } else if (month == 'Jul') {
      return 7;
    } else if (month == 'Jun') {
      return 6;
    } else if (month == 'May') {
      return 5;
    }else if (month == 'Apr') {
      return 4;
    }else if (month == 'Mar') {
      return 3;
    } else if (month == 'Feb') {
      return 2;
    } else 
      return 1;
  }

  returnKey(): number {
    let ret = this.allTransfers[0].id

    for(let t of this.allTransfers){
      if(t.id > ret)
        ret = t.id
    }

    return ret;
  }
}
