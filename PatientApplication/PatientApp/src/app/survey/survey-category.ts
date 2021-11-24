import { ISurveyQuestion } from "./survey-question";

export interface ISurveyCategory {
    id: number;
    name: string;
    surveyId: number;
    surveyQuestions: ISurveyQuestion[];
}