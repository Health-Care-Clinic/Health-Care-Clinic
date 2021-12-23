import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FeedbackViewComponent } from './component/feedback/feedback-view/feedback-view.component';
import { PharmacyRegistrationComponent } from './registration/pharmacy-registration/pharmacy-registration.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { HospitalMapComponent } from './component/hospital-map/hospital-map.component';
import { FloorComponent } from './component/hospital-map/floor.component';
import { UrgentProcurementComponent } from './component/urgent-procurement/urgent-procurement.component';
import { RoomSearchComponent } from './component/hospital-map/room-search.component';
import { EquipmentListComponent } from './component/moving-equipment/equipment-list.component';
import { SurveyObservationComponent } from './component/survey-observation/survey-observation.component';
import { PharmacyPromotionsComponent } from './pharmacy-promotions/pharmacy-promotions.component';
import { MedicineSpecificationsComponent } from './medicine-specifications/medicine-specifications/medicine-specifications.component';
import { ConsumptionReportComponent } from './consumption-report/consumption-report.component';
import { MaliciousPatientsComponent } from './component/malicious-patients/malicious-patients.component';
import { RenovationRoomsComponent } from './component/renovation-rooms/renovation-rooms.component';
import { RoomScheduleComponent } from './component/hospital-map/room-schedule.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { PharmacyProfilesComponent } from './pharmacy-profiles/pharmacy-profiles.component';
import { EditPharmacyProfileComponent } from './edit-pharmacy-profile/edit-pharmacy-profile.component';
import { AuthGuard } from './services/auth.guard';
import { LoginPageComponent } from './login-page/login-page.component';

const routes: Routes = [
  { path: '',  component: LandingPageComponent },
  { path: 'registration',  component: PharmacyRegistrationComponent },
  { path: 'login',  component: LoginPageComponent },
  { path: 'feedback-view', component: FeedbackViewComponent, canActivate:[AuthGuard]},
  { path: 'survey-observation', component: SurveyObservationComponent, canActivate:[AuthGuard]},
  { path: 'promotions', component: PharmacyPromotionsComponent, canActivate:[AuthGuard]},
  { path: 'notifications', component: NotificationsComponent, canActivate:[AuthGuard]},
  { path: 'registration', component: PharmacyRegistrationComponent, canActivate:[AuthGuard]},
  { path: 'floor/:idb/:idf', component: FloorComponent, canActivate:[AuthGuard] },
  { path: 'hospital-map', component: HospitalMapComponent, canActivate:[AuthGuard] },
  { path: 'floor/:idb/:idf/:idr', component: FloorComponent, canActivate:[AuthGuard] },
  { path: 'urgent-procurement', component: UrgentProcurementComponent, canActivate:[AuthGuard] },
  { path: 'hospital-map', component: HospitalMapComponent, canActivate:[AuthGuard] },
  { path: 'room-search-result/:searchText', component: RoomSearchComponent, canActivate:[AuthGuard] },
  { path: 'moving-equipment', component: EquipmentListComponent, canActivate:[AuthGuard] },
  { path: 'specifications', component: MedicineSpecificationsComponent, canActivate:[AuthGuard] },
  { path: 'consumption-report', component: ConsumptionReportComponent, canActivate:[AuthGuard] },
  { path: 'malicious-patients', component: MaliciousPatientsComponent, canActivate:[AuthGuard] },
  { path: 'renovation', component: RenovationRoomsComponent, canActivate:[AuthGuard] },
  { path: 'room-schedule/:idr', component: RoomScheduleComponent, canActivate:[AuthGuard] },
  { path: 'pharmacy-profiles', component: PharmacyProfilesComponent, canActivate:[AuthGuard] },
  { path: 'edit-pharmacy-profile/:idp', component: EditPharmacyProfileComponent, canActivate:[AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
