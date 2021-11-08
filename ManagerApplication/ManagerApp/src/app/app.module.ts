import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HospitalMapComponent } from './component/hospital-map/hospital-map.component';
import { FloorComponent } from './component/hospital-map/floor.component';
import { FeedbackViewComponent } from './component/feedback/feedback-view/feedback-view.component';
import { RouterModule } from '@angular/router';
import { FeedbackService } from './services/feedback.service';
import { HttpClientModule } from '@angular/common/http';
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
    HospitalMapComponent,
    FloorComponent,
    FeedbackViewComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    RouterModule.forRoot([
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
