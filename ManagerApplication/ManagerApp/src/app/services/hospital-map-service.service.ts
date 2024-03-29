import { Injectable } from '@angular/core';
import { Building, TypeOfBuilding } from '../model/building';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Floor } from '../model/floor';
import { Room, TypeOfRoom } from '../model/room';
import { Equipment } from '../model/equipment';
import { Transfer } from '../model/transfer';
import { Renovation } from '../model/renovation';
import { Appointment } from '../model/appointment';

/* const headers = { 'content-type': 'application/json',
                      'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')} */

@Injectable({
  providedIn: 'root'
})
export class HospitalMapService {

  private roomAppointmentsGet: string;
  private buildingsGet: string;
  private buildingGetById: string;
  private floorsGet: string;
  private roomsGet: string;
  private floorsGetByBuildingId: string;
  private roomsGetByFloorId: string;
  private changeBuildingNamePut: string;
  private equipmentGet: string;
  private equipmentGetByRoomId: string;
  private equipmentGetByName: string;
  private roomGetById: string;
  private floorGetById: string;
  private searchedBuildings: string;
  private searchedRooms: string;
  private transfersGet: string;
  private addNewTransfer: string;
  private checkFreeTransfersUrl: string;
  private checkRooms: string;
  private roomTransfersGet: string;
  private roomRenovationsGet: string;
  private isTransferCancellable: string;
  private cancelTransfer: string
  private isRenovationCancellable: string;
  private cancelRenovation: string;
  private addRoomUrl: string;

  constructor(private _http: HttpClient) {
    this.roomTransfersGet = '/api/transfer/getRoomTransfers'
    this.roomRenovationsGet = '/api/renovation/getRoomRenovations'
    this.roomAppointmentsGet = '/api/appointment/getRoomAppointments'
    this.buildingGetById = '/api/building/getBuildingById';
    this.buildingsGet = '/api/building/getBuildings';
    this.floorsGet = '/api/floor/getFloors';
    this.roomsGet = '/api/room/getRooms';
    this.floorsGetByBuildingId = '/api/floor/getFloorsByBuildingId';
    this.roomsGetByFloorId = '/api/room/getRoomsByFloorId'
    this.roomGetById = '/api/room/getRoomById'
    this.changeBuildingNamePut = '/api/building/changeBuildingName'
    this.equipmentGet = '/api/equipment/getAllEquipment'
    this.equipmentGetByRoomId = '/api/equipment/getEquipmentByRoomId'
    this.equipmentGetByName = '/api/equipment/getEquipmentByName'
    this.floorGetById = '/api/floor/getFloorById';
    this.searchedBuildings = '/api/building/getSearchedBuildings';
    this.searchedRooms = '/api/room/getSearchedRooms';
    this.transfersGet = '/api/transfer/getAllTransfers';
    this.addNewTransfer = '/api/transfer/addNewTransfer';
    this.checkFreeTransfersUrl = '/api/transfer/checkFreeTransfers';
    this.checkRooms = '/api/room/isFirstRoomNextToSecond';
    this.isTransferCancellable = '/api/transfer/checkIfTransferCancellable';
    this.isRenovationCancellable = '/api/renovation/checkIfRenovationCancellable';
    this.cancelTransfer = '/api/transfer/cancelTransfer';
    this.cancelRenovation = '/api/renovation/cancelRenovation';
    this.addRoomUrl = '/api/room/addRoom';
  }

  public deleteCancelledTransfer(transfer: Transfer):Observable<Transfer> {
    return this._http.post<Transfer>(this.cancelTransfer, transfer);
  }

  public deleteCancelledRenovation(renovation: Renovation):Observable<Renovation> {
    return this._http.post<Renovation>(this.cancelRenovation, renovation);
  }

  public checkIfTransferCancellable(transferId: number): Observable<Boolean> {
    return this._http.get<Boolean>(this.isTransferCancellable + "/" + transferId);
  }

  public checkIfRenovationCancellable(renovationId: number): Observable<Boolean> {
    return this._http.get<Boolean>(this.isRenovationCancellable + "/" + renovationId);
  }

  public getRoomTransfers(roomId: number): Observable<Array<Transfer>> {
    return this._http.get<Array<Transfer>>(this.roomTransfersGet + "/" + roomId);
  }

  public getRoomAppointments(roomId: number): Observable<Array<Appointment>> {
    return this._http.get<Array<Appointment>>(this.roomAppointmentsGet + "/" + roomId);
  }

  public getRoomRenovations(roomId: number): Observable<Array<Renovation>> {
    return this._http.get<Array<Renovation>>(this.roomRenovationsGet + "/" + roomId);
  }

  public getBuildings(): Observable<Array<Building>> {
    return this._http.get<Array<Building>>(this.buildingsGet);
  }

  public getSearchedBuildings(searchText:string): Observable<Array<Building>> {
    return this._http.get<Array<Building>>(this.searchedBuildings + "/" + searchText);
  }

  public getSearchedRooms(searchText:string): Observable<Array<Room>> {
    return this._http.get<Array<Room>>(this.searchedRooms + "/" + searchText);
  }

  public getBuildingById(buildingId:number): Observable<Building> {
    return this._http.get<Building>(this.buildingGetById + "/"+buildingId.toString());
  }

  public changeBuildingName(building:Building): Observable<any> {
    return this._http.put<any>(this.changeBuildingNamePut, building);
  }

  public getRoomById(Id:number): Observable<Room> {
    return this._http.get<Room>(this.roomGetById + "/"+Id.toString());
  }

  public getRoomsByFloorId(floorId:number): Observable<Array<Room>> {
    return this._http.get<Array<Room>>(this.roomsGetByFloorId + "/"+floorId.toString());
  }

  public getAllEquipment(): Observable<Array<Equipment>>{
    return this._http.get<Array<Equipment>>(this.equipmentGet);
  }

  public getEquipmentByRoomId(roomId:number): Observable<Array<Equipment>>{
    return this._http.get<Array<Equipment>>(this.equipmentGetByRoomId + "/"+roomId.toString());
  }

  public getEquipmentByName(name:string): Observable<Array<Equipment>>{
    return this._http.get<Array<Equipment>>(this.equipmentGetByName + "/"+name.toString());
  }
  

  public getFloorsByBuildingId(buildingId:number): Observable<Array<Floor>> {
    return this._http.get<Array<Floor>>(this.floorsGetByBuildingId + "/"+buildingId.toString());
    
  }

  public getFloorById(Id:number): Observable<Floor> {
    return this._http.get<Floor>(this.floorGetById + "/"+Id.toString());
  }

  public getRooms(): Observable<Array<Room>> {
    return this._http.get<Array<Room>>(this.roomsGet);
  }

  public getFloors(): Observable<Array<Floor>> {
    return this._http.get<Array<Floor>>(this.floorsGet);
  }

  public getTransfers(): Observable<Array<Transfer>> {
    return this._http.get<Array<Transfer>>(this.transfersGet);
  }

  public addTransfer(transfer:Transfer): Observable<Transfer> {
    return this._http.post<Transfer>(this.addNewTransfer, transfer);
  } 
  public checkFreeTransfers(transfer:Transfer): Observable<Array<Date>> {
    return this._http.post<Array<Date>>(this.checkFreeTransfersUrl, transfer);
  } 

  public IsFirstRoomNextToSecond(id1:number, id2:number): Observable<Boolean> {
    return this._http.get<Boolean>(this.checkRooms + "/"+ id1 + "/" + id2);
  }

  public addRoom(room: Room): Observable<Room> {
    return this._http.post<Room>(this.addRoomUrl, room);
  }
 
}
