import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { FeedbackFormComponent } from './feedback/feedback-form/feedback-form.component';

import { HttpClientModule } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FlexLayoutModule } from '@angular/flex-layout';
import {IvyCarouselModule} from 'angular-responsive-carousel';
import {CarouselModule} from 'primeng/carousel';
import {ButtonModule} from 'primeng/button';
import {ToastModule} from 'primeng/toast';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';  



import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MatIconModule  } from '@angular/material/icon';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
import {MatBadgeModule} from '@angular/material/badge';
import { MatCarouselModule } from 'ng-mat-carousel';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatStepperModule} from '@angular/material/stepper';
import {MatRadioModule} from '@angular/material/radio';
import {MatDividerModule} from '@angular/material/divider';
import {MatListModule} from '@angular/material/list';

import { FeedbackService } from './service/feedback.service';
import { SurveyService } from './survey/survey.service';
import { SurveyComponent } from './survey/survey.component';




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
  MatListModule
];

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    FeedbackFormComponent,
    HeaderComponent,
    FooterComponent,
    SurveyComponent,
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
    HttpClientModule
  ],
  providers: [FeedbackService, SurveyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
