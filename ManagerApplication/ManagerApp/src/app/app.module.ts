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

import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule  } from '@angular/material/icon';
import {MatTableModule} from '@angular/material/table';


const MaterialComponents = [
  MatSliderModule,
  MatToolbarModule,
  MatButtonModule,
  MatIconModule,
  MatTableModule
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
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    FormsModule,
    CommonModule,
    RouterModule.forRoot([
      { path: 'registration', component: PharmacyRegistrationComponent},
      { path: 'floor/:idb/:idf', component: FloorComponent },
      { path: '', component: HospitalMapComponent }
    ]),
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialComponents
  ],
  providers: [FeedbackService],
  bootstrap: [AppComponent]
})
export class AppModule { }
