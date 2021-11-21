import { Injectable } from '@angular/core';
import { Building, TypeOfBuilding } from '../model/building';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Floor } from '../model/floor';
import { Room, TypeOfRoom } from '../model/room';
import { Equipment } from '../model/equipment';

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
  private equipmentGetByRoomId: string;
  private equipmentGetByName: string;
  private roomGetById: string;
  private floorGetById: string;
  private searchedBuildings: string;
  private searchedRooms: string;

  constructor(private _http: HttpClient) {
    this.buildingGetById = '/api/building/getBuildingById';
    this.buildingsGet = '/api/building/getBuildings';
    this.floorsGet = '/api/floor/getFloors';
    this.roomsGet = '/api/room/getRooms';
    this.floorsGetByBuildingId = '/api/floor/getFloorsByBuildingId';
    this.roomsGetByFloorId = '/api/room/getRoomsByFloorId'
    this.roomGetById = '/api/room/getRoomById'
    this.changeBuildingNamePut = '/api/building/changeBuildingName'
    this.equipmentGetByRoomId = '/api/equipment/getEquipmentByRoomId'
    this.equipmentGetByName = '/api/equipment/getEquipmentByName'
    this.floorGetById = '/api/floor/getFloorById';
    this.searchedBuildings = '/api/building/getSearchedBuildings';
    this.searchedRooms = '/api/room/getSearchedRooms';
  }

  public getBuildings(): Observable<Array<Building>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Building>>(this.buildingsGet, {headers: headers});
    
  }

  public getSearchedBuildings(searchText:string): Observable<Array<Building>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Building>>(this.searchedBuildings + "/" + searchText, {headers: headers});
  }

  public getSearchedRooms(searchText:string): Observable<Array<Room>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Room>>(this.searchedRooms + "/" + searchText, {headers: headers});
  }

  public getBuildingById(buildingId:number): Observable<Building> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Building>(this.buildingGetById + "/"+buildingId.toString(), {headers: headers});
    
  }

  public changeBuildingName(building:Building): Observable<any> {
    return this._http.put<any>(this.changeBuildingNamePut, building);
    
  }

  public getRoomById(Id:number): Observable<Room> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Room>(this.roomGetById + "/"+Id.toString(), {headers: headers});
  }

  public getRoomsByFloorId(floorId:number): Observable<Array<Room>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Room>>(this.roomsGetByFloorId + "/"+floorId.toString(), {headers: headers});
  }

  public getEquipmentByRoomId(roomId:number): Observable<Array<Equipment>>{
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Equipment>>(this.equipmentGetByRoomId + "/"+roomId.toString(), {headers: headers});

  }
  public getEquipmentByName(name:string): Observable<Array<Equipment>>{
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Equipment>>(this.equipmentGetByName + "/"+name.toString(), {headers: headers});

  }
  

  public getFloorsByBuildingId(buildingId:number): Observable<Array<Floor>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Array<Floor>>(this.floorsGetByBuildingId + "/"+buildingId.toString(), {headers: headers});
    
  }

  public getFloorById(Id:number): Observable<Floor> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    return this._http.get<Floor>(this.floorGetById + "/"+Id.toString(), {headers: headers});
    
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
