export class Appointment {
    id:number;
    patientId:number;
    doctorId:number;
    isCancelled:boolean;
    isDone:boolean;
    roomId:number;
    date: Date;
    surveyId: number;

    constructor(id:number,patientId:number,doctorId:number,isCancelled:boolean,roomId:number,isDone:boolean,date: Date,surveyId: number){
        this.id = id;
        this.patientId = patientId;
        this.doctorId = doctorId;
        this.isCancelled = isCancelled;
        this.roomId = roomId;
        this.isDone = isDone;
        this.date = date;
        this.surveyId = surveyId;
    }
}
