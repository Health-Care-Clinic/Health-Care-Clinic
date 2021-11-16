import { Injectable } from '@angular/core';
import { Building, TypeOfBuilding } from '../model/building';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Floor } from '../model/floor';
import { Room, TypeOfRoom } from '../model/room';

@Injectable({
  providedIn: 'root'
})
export class HospitalMapService {

  private buildingsGet: string;
  private buildingGetById: string;
  private floorsGet: string;
  private roomsGet: string;
  private floorsGetByBuildingId: string;
  private roomsGetByFloorId: string;
  private changeBuildingNamePut: string;

  constructor(private _http: HttpClient) {
    this.buildingGetById = '/api/hospitalMap/getBuildingById';
    this.buildingsGet = '/api/hospitalMap/getBuildings';
    this.floorsGet = '/api/hospitalmap/getFloors';
    this.roomsGet = '/api/hospitalmap/getRooms';
    this.floorsGetByBuildingId = '/api/hospitalmap/getFloorsByBuildingId';
    this.roomsGetByFloorId = '/api/hospitalmap/getRoomsByFloorId'
    this.changeBuildingNamePut = '/api/hospitalmap/changeBuildingName'
  }

  public getBuildings(): Observable<Array<Building>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Building>>(this.buildingsGet, {headers: headers});
    
  }

  public getBuildingById(buildingId:number): Observable<Building> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Building>(this.buildingGetById + "/"+buildingId.toString(), {headers: headers});
    
  }

  public changeBuildingName(building:Building): Observable<any> {
    return this._http.put<any>(this.changeBuildingNamePut, building);
    
  }

  public getRoomsByFloorId(floorId:number): Observable<Array<Room>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Room>>(this.roomsGetByFloorId + "/"+floorId.toString(), {headers: headers});
  }

  

  public getFloorsByBuildingId(buildingId:number): Observable<Array<Floor>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Floor>>(this.floorsGetByBuildingId + "/"+buildingId.toString(), {headers: headers});
    
  }

  public getRooms(): Observable<Array<Room>> {
    
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Room>>(this.roomsGet, {headers: headers});
  }

  public getFloors(): Observable<Array<Floor>> {
    
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Floor>>(this.floorsGet, {headers: headers});
  }
 
}
