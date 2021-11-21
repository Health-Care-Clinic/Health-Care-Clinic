import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PharmacyRegistrationComponent } from './registration/pharmacy-registration/pharmacy-registration.component';
import { HospitalMapComponent } from './component/hospital-map/hospital-map.component';
import { FloorComponent } from './component/hospital-map/floor.component';
import { FeedbackViewComponent } from './component/feedback/feedback-view/feedback-view.component';
import { FeedbackPublishComponent } from './component/feedback/feedback-publish/feedback-publish.component';
import { RouterModule } from '@angular/router';
import { FeedbackService } from './services/feedback.service';
import { HeaderComponent } from './component/header/header.component';
import { FooterComponent } from './component/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LandingPageComponent } from './landing-page/landing-page.component';
import {IvyCarouselModule} from 'angular-responsive-carousel';

import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule  } from '@angular/material/icon';
import {MatTableModule} from '@angular/material/table';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
import {MatBadgeModule} from '@angular/material/badge';
import { MatCarouselModule } from 'ng-mat-carousel';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { RoomSearchComponent } from './component/hospital-map/room-search.component';



const MaterialComponents = [
  MatTableModule,
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
  MatCheckboxModule
];

@NgModule({
  declarations: [
    AppComponent,
    PharmacyRegistrationComponent,
    HospitalMapComponent,
    FloorComponent,
    FeedbackViewComponent,
    FeedbackPublishComponent,
    HeaderComponent,
    FooterComponent,
    LandingPageComponent,
    RoomSearchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    FormsModule,
    CommonModule,
    RouterModule.forRoot([
    ]),
    HttpClientModule,
    BrowserAnimationsModule,
    IvyCarouselModule,
    MaterialComponents
  ],
  providers: [FeedbackService],
  bootstrap: [AppComponent]
})
export class AppModule { }
