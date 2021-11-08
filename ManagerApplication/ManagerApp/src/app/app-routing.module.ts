import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { PharmacyRegistrationComponent } from './registration/pharmacy-registration/pharmacy-registration.component';

const routes: Routes = [
  {
    path: 'registration',
    component: PharmacyRegistrationComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
