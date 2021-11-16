import { ISurveyQuestion } from "./survey-question";

export interface ISurvey {
    id: number;
    patientId: number;
    appointmentId: number;
    surveyQuestions: ISurveyQuestion[];
}