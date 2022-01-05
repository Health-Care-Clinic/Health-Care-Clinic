import { CommonModule, DatePipe } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PharmacyRegistrationComponent } from './registration/pharmacy-registration/pharmacy-registration.component';
import { HospitalMapComponent } from './component/hospital-map/hospital-map.component';
import { FloorComponent } from './component/hospital-map/floor.component';
import { EquipmentListComponent } from './component/moving-equipment/equipment-list.component';
import { FeedbackViewComponent } from './component/feedback/feedback-view/feedback-view.component';
import { FeedbackPublishComponent } from './component/feedback/feedback-publish/feedback-publish.component';
import { RouterModule } from '@angular/router';
import { FeedbackService } from './services/feedback.service';
import { HeaderComponent } from './component/header/header.component';
import { FooterComponent } from './component/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { IvyCarouselModule } from 'angular-responsive-carousel';

import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import {MatTableModule} from '@angular/material/table';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
import {MatBadgeModule} from '@angular/material/badge';
import { MatCarouselModule } from 'ng-mat-carousel';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatStepperModule} from '@angular/material/stepper';
import {MatListModule} from '@angular/material/list';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatMenuModule} from '@angular/material/menu';

import { SurveyObservationComponent } from './component/survey-observation/survey-observation.component';
import { SurveyObservationService } from './services/survey-observation.service';
import { UrgentProcurementComponent } from './component/urgent-procurement/urgent-procurement.component';
import { PharmacyCityFilterPipe } from './pipes/pharmacy-city-filter.pipe';
import { OrderDialogComponent } from './component/urgent-procurement/order-dialog/order-dialog.component';


import { RoomSearchComponent } from './component/hospital-map/room-search.component';
import { PharmacyPromotionsComponent } from './pharmacy-promotions/pharmacy-promotions.component';
import { MatExpansionModule } from '@angular/material/expansion';
import {MatTooltipModule} from '@angular/material/tooltip';
import { MedicineSpecificationsComponent } from './medicine-specifications/medicine-specifications/medicine-specifications.component';
import { ConsumptionReportComponent } from './consumption-report/consumption-report.component';
import { MaliciousPatientsComponent } from './component/malicious-patients/malicious-patients.component';
import { NotificationsComponent } from './notifications/notifications.component';

import { RenovationRoomsComponent } from './component/renovation-rooms/renovation-rooms.component';
import { RoomScheduleComponent } from './component/hospital-map/room-schedule.component';
import { PharmacyProfilesComponent } from './pharmacy-profiles/pharmacy-profiles.component';
import { EditPharmacyProfileComponent } from './edit-pharmacy-profile/edit-pharmacy-profile.component';
import { TendersComponent } from './tenders/tenders.component';
import { CreateTenderComponent } from './create-tender/create-tender.component';
import { DoctorsComponent } from './component/doctors/doctors.component';
import { OnCallShiftComponent } from './component/on-call-shift/on-call-shift.component';
import { NewOnCallShiftComponent } from './component/new-on-call-shift/new-on-call-shift.component';
import { DoctorVacationsComponent } from './component/doctor-vacations/doctor-vacations.component';
import { AddingShiftComponent } from './component/adding-shift/adding-shift.component';
import { ShiftsComponent } from './component/shifts/shifts.component';
import { AddShiftComponent } from './component/shifts/add-shift/add-shift.component';
import { EditShiftComponent } from './component/shifts/edit-shift/edit-shift.component';

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
  MatCheckboxModule,
  MatStepperModule,
  MatListModule,
  MatExpansionModule,
  MatTooltipModule,
  MatSnackBarModule,
  MatMenuModule
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
    UrgentProcurementComponent,
    PharmacyCityFilterPipe,
    OrderDialogComponent,
    RoomSearchComponent,
    EquipmentListComponent,
    SurveyObservationComponent,
    PharmacyPromotionsComponent,
    MedicineSpecificationsComponent,
    ConsumptionReportComponent,
    MaliciousPatientsComponent,
    RenovationRoomsComponent,
    RoomScheduleComponent,
    NotificationsComponent,
    PharmacyProfilesComponent,
    EditPharmacyProfileComponent,
    TendersComponent,
    CreateTenderComponent,
    DoctorsComponent,
    OnCallShiftComponent,
    NewOnCallShiftComponent,
    DoctorVacationsComponent,
    ShiftsComponent,
    AddingShiftComponent,
    AddShiftComponent,
    EditShiftComponent
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
  providers: [FeedbackService, SurveyObservationService],
  bootstrap: [AppComponent],
  entryComponents: [OrderDialogComponent]
})
export class AppModule { }
