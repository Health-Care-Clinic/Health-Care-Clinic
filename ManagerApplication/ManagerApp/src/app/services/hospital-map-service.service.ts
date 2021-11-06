import { Injectable } from '@angular/core';
import { Building, TypeOfBuilding } from '../model/building';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Floor } from '../model/floor';
import { Room, TypeOfRoom } from '../model/room';

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
    
    let rooms: any;
    rooms = this.getRooms();
    
    let building1 = new Building(1,260,30,400,140,"Building1",TypeOfBuilding.Hospital,[new Floor(1, "Sprat 1", rooms), new Floor(2, "Sprat 2", rooms), new Floor(3, "Sprat 3", rooms)]);
    let building2 = new Building(2,260,230,400,140,"Building2",TypeOfBuilding.Hospital,[new Floor(4, "Sprat 1", rooms), new Floor(5, "Sprat 2", rooms)]);
    let building3 = new Building(3,30,130,180,240,"Building3",TypeOfBuilding.Hospital,[new Floor(6, "Sprat 1", rooms), new Floor(7, "Sprat 2", rooms), new Floor(8, "Sprat 3", rooms)]);
    let building4 = new Building(4,700,230,300,140,"Building4",TypeOfBuilding.Hospital,[new Floor(9, "Sprat 1", rooms), new Floor(10, "Sprat 2", rooms)]);
    let building5 = new Building(5,30,30,200,70,"Parking1",TypeOfBuilding.Parking,null);
    let building6 = new Building(6,800,30,200,70,"Parking2",TypeOfBuilding.Parking,null);
    let building7 = new Building(7,800,130,200,70,"Parking3",TypeOfBuilding.Parking,null);
    buildings=[
      building1,building2,building3,building4,building5,building6,building7
    ]
    return buildings;
  }

  public getBuildingFloors(index: number): Observable<Array<Floor>> {
    let floors: any;

    let rooms1: any;
    rooms1 = this.getFloorRooms(1);
    let rooms2: any;
    rooms2 = this.getFloorRooms(2);
    let rooms3: any;
    rooms3 = this.getFloorRooms(3);

    let floor1 = new Floor(1, "Sprat 1", rooms1);
    let floor2 = new Floor(2, "Sprat 2", rooms2);
    let floor3 = new Floor(3, "Sprat 3", rooms3);

    floors = [floor1, floor2, floor3];

    return floors;
  }

  public getFloorRooms(index: number): Observable<Array<Room>> {
    let rooms: any;
    
    let room1 = new Room(1, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room2 = new Room(2, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room3 = new Room(3,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room4 = new Room(4, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room5 = new Room(5, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);
    rooms = [room1, room2, room3, room4, room5]

    return rooms;
  }

  public getRooms(): Observable<Array<Room>> {
    let rooms: any;
    
    let room1 = new Room(1, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room2 = new Room(2, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room3 = new Room(3,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room4 = new Room(4, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room5 = new Room(5, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);

    rooms = [room1, room2, room3, room4, room5]

    let room6 = new Room(6, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room7 = new Room(7, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room8 = new Room(8,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room9 = new Room(9, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room10 = new Room(10, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);

    let room11 = new Room(11, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room12 = new Room(12, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room13 = new Room(13,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room14 = new Room(14, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room15 = new Room(15, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);

    let room16 = new Room(16, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room17 = new Room(17, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room18 = new Room(18,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room19 = new Room(19, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room20 = new Room(20, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);

    let room21 = new Room(21, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room22 = new Room(22, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room23 = new Room(23,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room24 = new Room(24, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room25 = new Room(25, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);

    let room26 = new Room(26, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room27 = new Room(27, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room28 = new Room(28,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room29 = new Room(29, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room30 = new Room(30, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);

    let room31 = new Room(31, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room32 = new Room(32, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room33 = new Room(33,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room34 = new Room(34, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room35 = new Room(35, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);

    let room36 = new Room(36, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room37 = new Room(37, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room38 = new Room(38,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room39 = new Room(39, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room40 = new Room(40, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);

    let room41 = new Room(41, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room42 = new Room(42, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room43 = new Room(43,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room44 = new Room(44, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room45 = new Room(45, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);

    let room46 = new Room(46, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room47 = new Room(47, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room48 = new Room(48,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room49 = new Room(49, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room50 = new Room(50, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);

    let room51 = new Room(51, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room52 = new Room(52, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room53 = new Room(53,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room54 = new Room(54, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room55 = new Room(55, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);

    let room56 = new Room(56, 'Operaciona sala', 'Opis1', 'Pera Peric', 12, TypeOfRoom.OperationRoom,260,30,400,140);
    let room57 = new Room(57, 'Toalet', 'Opis2', 'Dejan Bodiroga', 24, TypeOfRoom.Other,260,230,400,140);
    let room58 = new Room(58,'Soba za pregled', 'Kardiolog', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,30,130,180,240);
    let room59 = new Room(59, 'Sala za pregled', 'Radiolog', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,230,300,140);
    let room60 = new Room(60, 'Kuhinja', 'Opis5', 'Darko Milicic', 24, TypeOfRoom.Other,30,30,200,70);

    return rooms;
  }
 
}
