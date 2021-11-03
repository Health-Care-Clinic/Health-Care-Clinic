import { Injectable } from '@angular/core';
import { Building, TypeOfBuilding } from '../model/building';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Floor } from '../model/floor';

@Injectable({
  providedIn: 'root'
})
export class HospitalMapService {

  private buildingsGet: string;

 

  constructor() {
    this.buildingsGet = 'http://localhost:8080/getBuildings';
  
  }

  public getBuildings(): Observable<Array<Building>> {
    let buildings: any;
    let building1 = new Building(1,260,30,400,140,"Building1",TypeOfBuilding.Hospital,[new Floor(1, "Sprat 1", null), new Floor(2, "Sprat 2", null), new Floor(3, "Sprat 3", null)]);
    let building2 = new Building(2,260,230,400,140,"Building2",TypeOfBuilding.Hospital,[new Floor(4, "Sprat 1", null), new Floor(5, "Sprat 2", null)]);
    let building3 = new Building(3,30,130,180,240,"Building3",TypeOfBuilding.Hospital,[new Floor(6, "Sprat 1", null), new Floor(7, "Sprat 2", null), new Floor(8, "Sprat 3", null)]);
    let building4 = new Building(4,700,230,300,140,"Building4",TypeOfBuilding.Hospital,[new Floor(9, "Sprat 1", null), new Floor(10, "Sprat 2", null)]);
    let building5 = new Building(5,30,30,200,70,"Parking1",TypeOfBuilding.Parking,null);
    let building6 = new Building(6,800,30,200,70,"Parking2",TypeOfBuilding.Parking,null);
    let building7 = new Building(7,800,130,200,70,"Parking3",TypeOfBuilding.Parking,null);
    buildings=[
      building1,building2,building3,building4,building5,building6,building7
    ]
    return buildings;
  }
 
}
