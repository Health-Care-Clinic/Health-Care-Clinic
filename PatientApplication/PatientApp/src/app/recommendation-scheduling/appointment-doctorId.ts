export interface AppointmentWithDoctorId {
    
    id : number;

    patientId : number;

    doctorId : number;

    roomId : number;

    isCancelled : boolean;

    isDone : boolean;

    date : Date;

    surveyId : number;
}