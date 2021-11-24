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
import { PharmacyPromotionsComponent } from './pharmacy-promotions/pharmacy-promotions.component';
import { MedicineSpecificationsComponent } from './medicine-specifications/medicine-specifications/medicine-specifications.component';
import { ConsumptionReportComponent } from './consumption-report/consumption-report.component';

const routes: Routes = [
  { path: '',  component: LandingPageComponent },
  { path: 'registration',  component: PharmacyRegistrationComponent },
  { path: 'feedback-view', component: FeedbackViewComponent},
  { path: 'promotions', component: PharmacyPromotionsComponent},
  { path: 'registration', component: PharmacyRegistrationComponent},
  { path: 'floor/:idb/:idf', component: FloorComponent },
  { path: 'hospital-map', component: HospitalMapComponent },
  { path: 'floor/:idb/:idf/:idr', component: FloorComponent },
  { path: 'urgent-procurement', component: UrgentProcurementComponent },
  { path: 'hospital-map', component: HospitalMapComponent },
  { path: 'hospital-map', component: HospitalMapComponent },
  { path: 'room-search-result/:searchText', component: RoomSearchComponent },
  { path: 'moving-equipment', component: EquipmentListComponent },
  { path: 'specifications', component: MedicineSpecificationsComponent },
  { path: 'consumption-report', component: ConsumptionReportComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
