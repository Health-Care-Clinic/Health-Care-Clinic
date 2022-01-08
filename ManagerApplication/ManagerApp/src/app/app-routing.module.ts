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
import { TendersComponent } from './tenders/tenders.component';
import { CreateTenderComponent } from './create-tender/create-tender.component';
import { DoctorsComponent } from './component/doctors/doctors.component';
import { OnCallShiftComponent } from './component/on-call-shift/on-call-shift.component';
import { NewOnCallShiftComponent } from './component/new-on-call-shift/new-on-call-shift.component';
import { DoctorVacationsComponent } from './component/doctor-vacations/doctor-vacations.component';
import { AddingShiftComponent } from './component/adding-shift/adding-shift.component';
import { ShiftsComponent } from './component/shifts/shifts.component';
import { AddShiftComponent } from './component/shifts/add-shift/add-shift.component';
import { EditDoctorShiftComponent } from './component/edit-doctor-shift/edit-doctor-shift.component';
import { ScheduleDoctorVacationComponent } from './component/schedule-doctor-vacation/schedule-doctor-vacation.component';
import { WorkloadComponent } from './component/workload/workload.component';
import { EditShiftComponent } from './component/shifts/edit-shift/edit-shift.component';
import { ChangeDoctorVacationComponent } from './component/change-doctor-vacation/change-doctor-vacation.component';

const routes: Routes = [
  { path: '',  component: LandingPageComponent },
  { path: 'registration',  component: PharmacyRegistrationComponent },
  { path: 'feedback-view', component: FeedbackViewComponent},
  { path: 'survey-observation', component: SurveyObservationComponent},
  { path: 'promotions', component: PharmacyPromotionsComponent},
  { path: 'notifications', component: NotificationsComponent},
  { path: 'registration', component: PharmacyRegistrationComponent},
  { path: 'floor/:idb/:idf', component: FloorComponent },
  { path: 'hospital-map', component: HospitalMapComponent },
  { path: 'add-shift', component: AddShiftComponent },
  { path: 'floor/:idb/:idf/:idr', component: FloorComponent },
  { path: 'urgent-procurement', component: UrgentProcurementComponent },
  { path: 'hospital-map', component: HospitalMapComponent },
  { path: 'hospital-map', component: HospitalMapComponent },
  { path: 'room-search-result/:searchText', component: RoomSearchComponent },
  { path: 'moving-equipment', component: EquipmentListComponent },
  { path: 'specifications', component: MedicineSpecificationsComponent },
  { path: 'consumption-report', component: ConsumptionReportComponent },
  { path: 'malicious-patients', component: MaliciousPatientsComponent },
  { path: 'renovation', component: RenovationRoomsComponent },
  { path: 'shifts', component: ShiftsComponent },
  { path: 'room-schedule/:idr', component: RoomScheduleComponent },
  { path: 'pharmacy-profiles', component: PharmacyProfilesComponent },
  { path: 'edit-pharmacy-profile/:idp', component: EditPharmacyProfileComponent },
  { path: 'tenders', component: TendersComponent },
  { path: 'create-tender', component: CreateTenderComponent },
  { path: 'doctors', component: DoctorsComponent },
  { path: 'on-call-shifts/:ido', component: OnCallShiftComponent},
  { path: 'workload/:ido', component: WorkloadComponent},
  { path: 'edit-pharmacy-profile/:idp', component: EditPharmacyProfileComponent },
  { path: 'new-on-call-shift/:ide', component: NewOnCallShiftComponent },
  { path: 'doctor-vacations/:iddv', component: DoctorVacationsComponent},
  { path: 'edit-pharmacy-profile/:idp', component: EditPharmacyProfileComponent },
  { path: 'add-new-shift/:ida', component: AddingShiftComponent },
  { path: 'edit-doctor-shift/:idu', component: EditDoctorShiftComponent },
  { path: 'schedule-a-vacation/:iddc', component: ScheduleDoctorVacationComponent},
  { path: 'change-a-vacation/:idvc', component: ChangeDoctorVacationComponent},
  { path: 'edit-pharmacy-profile/:idp', component: EditPharmacyProfileComponent },
  { path: 'edit-pharmacy-profile/:idp', component: EditPharmacyProfileComponent },
  { path: 'edit-shift/:ids', component: EditShiftComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
