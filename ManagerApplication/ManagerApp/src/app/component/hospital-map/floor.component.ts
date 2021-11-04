import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { HospitalMapService } from 'src/app/services/hospital-map-service.service';


@Component({
  selector: 'app-floor',
  templateUrl: './floor.component.html',
  styleUrls: ['./floor.component.css']
})
export class FloorComponent implements OnInit {


  building: any;
  buildings: any;
  floor: any;
  idfString: string
  navigationSubscription; 

  constructor(private _route: ActivatedRoute, private hospitalMapService: HospitalMapService, private router: Router) {
    this.navigationSubscription = this.router.events.subscribe((e: any) => {
      if (e instanceof NavigationEnd) {
        this.initialiseClass();
      }
    });
  }

  ngOnInit(): void {
    this.buildings = this.hospitalMapService.getBuildings();
    let idb = +this._route.snapshot.paramMap.get('idb');
    this.building = this.buildings.find(i => i.id === idb);
    this.idfString = this._route.snapshot.paramMap.get('idf');
    let idf = +this.idfString;
    this.floor = this.building.floors.find(i => i.id === idf);
  }

  initialiseClass(): void {
    this.buildings = this.hospitalMapService.getBuildings();
    let idb = +this._route.snapshot.paramMap.get('idb');
    this.building = this.buildings.find(i => i.id === idb);
    this.idfString = this._route.snapshot.paramMap.get('idf');
    let idf = +this.idfString;
    this.floor = this.building.floors.find(i => i.id === idf);
  }

  ngOnDestroy() {
    if (this.navigationSubscription) {
      this.navigationSubscription.unsubscribe();
    }
  }

}
