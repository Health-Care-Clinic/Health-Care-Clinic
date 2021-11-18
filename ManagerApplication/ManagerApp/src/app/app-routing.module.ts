import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FeedbackViewComponent } from './component/feedback/feedback-view/feedback-view.component';
import { PharmacyRegistrationComponent } from './registration/pharmacy-registration/pharmacy-registration.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { HospitalMapComponent } from './component/hospital-map/hospital-map.component';
import { FloorComponent } from './component/hospital-map/floor.component';

const routes: Routes = [
  { path: '',  component: LandingPageComponent },
  { path: 'registration',  component: PharmacyRegistrationComponent },
  { path: 'feedback-view', component: FeedbackViewComponent},
  { path: 'registration', component: PharmacyRegistrationComponent},
  { path: 'floor/:idb/:idf', component: FloorComponent },
  { path: 'floor/:idb/:idf/:idr', component: FloorComponent },
  { path: 'hospital-map', component: HospitalMapComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
