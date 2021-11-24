import { ISurveyQuestionStatistics } from "./survey-question-statistics";

export interface ISurveyCategoryStatistics {
    name: string;
    averageGrade: number;
    surveyQuestionsStatistics: ISurveyQuestionStatistics[];
}
