import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FeedbackFormComponent } from './feedback/feedback-form/feedback-form.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { MedicalRecordComponent } from './medical-record/medical-record.component';
import { RecommendationSchedulingComponent } from './recommendation-scheduling/recommendation-scheduling.component';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { SurveyComponent } from './survey/survey.component';

const routes: Routes = [
  { path: '', component: LandingPageComponent },
  { path: 'feedback-form', component: FeedbackFormComponent },
  { path: 'survey', component: SurveyComponent },
  { path: 'register', component: RegistrationFormComponent },
  { path: 'login', component: LoginPageComponent },
  { path: 'medical-record', component: MedicalRecordComponent },
  { path: 'recommendation-scheduling', component: RecommendationSchedulingComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
