import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { FeedbackFormComponent } from './feedback/feedback-form/feedback-form.component';

import { HttpClientModule } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FlexLayoutModule } from '@angular/flex-layout';
import { IvyCarouselModule} from 'angular-responsive-carousel';
import { CarouselModule} from 'primeng/carousel';
import { ButtonModule} from 'primeng/button';
import { ToastModule} from 'primeng/toast';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {MatTableModule} from '@angular/material/table';

import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MatIconModule  } from '@angular/material/icon';
import { MatGridListModule} from '@angular/material/grid-list';
import { MatCardModule} from '@angular/material/card';
import { MatBadgeModule} from '@angular/material/badge';
import { MatCarouselModule } from 'ng-mat-carousel';
import { MatDialogModule} from '@angular/material/dialog';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule} from '@angular/material/input';
import { MatCheckboxModule} from '@angular/material/checkbox';
import { MatStepperModule} from '@angular/material/stepper';
import { MatRadioModule} from '@angular/material/radio';
import { MatDividerModule} from '@angular/material/divider';
import { MatListModule} from '@angular/material/list';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule} from '@angular/material/select';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatTabsModule} from '@angular/material/tabs';
import {MatMenuModule} from '@angular/material/menu';

import { FeedbackService } from './service/feedback.service';
import { SurveyService } from './survey/survey.service';
import { SurveyComponent } from './survey/survey.component';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { PatientService } from './patient/patient.service';
import { LoginPageComponent } from './login-page/login-page.component';
import { MedicalRecordComponent } from './medical-record/medical-record.component';
import { RecommendationSchedulingComponent } from './recommendation-scheduling/recommendation-scheduling.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { AppointmentService } from './service/appointment.service';



const MaterialComponents = [
  MatSliderModule,
  MatToolbarModule,
  MatButtonModule,
  MatIconModule,
  MatGridListModule,
  MatCardModule,
  MatBadgeModule,
  MatCarouselModule.forRoot(),
  MatDialogModule,
  MatFormFieldModule,
  MatInputModule,
  MatCheckboxModule,
  MatStepperModule,
  MatRadioModule,
  MatDividerModule,
  MatListModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatSelectModule,
  MatSnackBarModule,
  MatTabsModule,
  MatMenuModule,
  MatTableModule
];

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    FeedbackFormComponent,
    HeaderComponent,
    FooterComponent,
    SurveyComponent,
    RegistrationFormComponent,
    LoginPageComponent,
    MedicalRecordComponent,
    RecommendationSchedulingComponent,
    AppointmentsComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    FlexLayoutModule,
    IvyCarouselModule,
    CarouselModule,
    ButtonModule,
    ToastModule,
    NgbModule,
    MaterialComponents,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [FeedbackService, SurveyService, PatientService, AppointmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
