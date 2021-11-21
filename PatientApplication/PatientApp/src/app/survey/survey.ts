import { ISurveyCategory } from "./survey-category";

export interface ISurvey {
    id: number;
    appointmentId: number;
    done: boolean;
    surveyCategories: ISurveyCategory[];
}