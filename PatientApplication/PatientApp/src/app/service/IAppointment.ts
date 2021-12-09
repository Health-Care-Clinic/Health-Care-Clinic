import { Doctor } from "../registration-form/doctor";
import { ISurvey } from "../survey/survey";
import { ISurveyForAppointment } from "../survey/survey";

export interface IAppointment {
    
        id : number;

        patientId : number;

        doctorDTO : Doctor;

        roomId : number;

        isCancelled : boolean;

        isDone : boolean;

        date : Date;

        surveyDTO : ISurveyForAppointment;
}
