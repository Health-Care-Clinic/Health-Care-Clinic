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
import { TendersComponent } from './tenders/tenders.component';
import { CreateTenderComponent } from './create-tender/create-tender.component';
import { DoctorsComponent } from './component/doctors/doctors.component';
import { OnCallShiftComponent } from './component/on-call-shift/on-call-shift.component';
import { NewOnCallShiftComponent } from './component/new-on-call-shift/new-on-call-shift.component';
import { DoctorVacationsComponent } from './component/doctor-vacations/doctor-vacations.component';
import { AddingShiftComponent } from './component/adding-shift/adding-shift.component';
import { ShiftsComponent } from './component/shifts/shifts.component';
import { AddShiftComponent } from './component/shifts/add-shift/add-shift.component';
import { TenderStatisticsComponent } from './tender-statistics/tender-statistics.component';
import { EditDoctorShiftComponent } from './component/edit-doctor-shift/edit-doctor-shift.component';
import { ScheduleDoctorVacationComponent } from './component/schedule-doctor-vacation/schedule-doctor-vacation.component';
import { WorkloadComponent } from './component/workload/workload.component';
import { EditShiftComponent } from './component/shifts/edit-shift/edit-shift.component';
import { ChangeDoctorVacationComponent } from './component/change-doctor-vacation/change-doctor-vacation.component';
import { DeleteDoctorVacationComponent } from './component/delete-doctor-vacation/delete-doctor-vacation.component';
import { TenderOffersComponent } from './tender-offers/tender-offers.component';
import { PharmacyTenderStatisticsComponent } from './pharmacy-tender-statistics/pharmacy-tender-statistics.component';

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
  { path: 'edit-pharmacy-profile/:idp', component: EditPharmacyProfileComponent, canActivate:[AuthGuard] },
  { path: 'add-shift', component: AddShiftComponent },
  { path: 'shifts', component: ShiftsComponent },
  { path: 'tenders', component: TendersComponent },
  { path: 'create-tender', component: CreateTenderComponent },
  { path: 'tender-statistics', component: TenderStatisticsComponent},
  { path: 'doctors', component: DoctorsComponent },
  { path: 'on-call-shifts/:ido', component: OnCallShiftComponent},
  { path: 'workload/:ido', component: WorkloadComponent},
  { path: 'edit-pharmacy-profile/:idp', component: EditPharmacyProfileComponent },
  { path: 'pharmacy-tender-statistics/:idp', component: PharmacyTenderStatisticsComponent },
  { path: 'new-on-call-shift/:ide', component: NewOnCallShiftComponent },
  { path: 'doctor-vacations/:iddv', component: DoctorVacationsComponent},
  { path: 'edit-pharmacy-profile/:idp', component: EditPharmacyProfileComponent },
  { path: 'add-new-shift/:ida', component: AddingShiftComponent },
  { path: 'edit-doctor-shift/:idu', component: EditDoctorShiftComponent },
  { path: 'schedule-a-vacation/:iddc', component: ScheduleDoctorVacationComponent},
  { path: 'change-a-vacation/:idvc', component: ChangeDoctorVacationComponent},
  { path: 'delete-a-vacation/:idvd', component: DeleteDoctorVacationComponent},
  { path: 'edit-pharmacy-profile/:idp', component: EditPharmacyProfileComponent },
  { path: 'edit-pharmacy-profile/:idp', component: EditPharmacyProfileComponent },
  { path: 'edit-shift/:ids', component: EditShiftComponent },
  { path: 'tender-offers/:id', component: TenderOffersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
