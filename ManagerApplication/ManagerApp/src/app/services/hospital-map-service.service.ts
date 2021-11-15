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
    
    let building1 = new Building(1,260,30,400,140,"Building1",TypeOfBuilding.Hospital,[new Floor(1, "Floor 1", rooms), new Floor(2, "Floor 2", rooms), new Floor(3, "Floor 3", rooms)]);
    let building2 = new Building(2,260,230,400,140,"Building2",TypeOfBuilding.Hospital,[new Floor(4, "Floor 1", rooms), new Floor(5, "Floor 2", rooms)]);
    let building3 = new Building(3,30,130,180,240,"Building3",TypeOfBuilding.Hospital,[new Floor(6, "Floor 1", rooms), new Floor(7, "Floor 2", rooms), new Floor(8, "Floor 3", rooms)]);
    let building4 = new Building(4,700,230,300,140,"Building4",TypeOfBuilding.Hospital,[new Floor(9, "Floor 1", rooms), new Floor(10, "Floor 2", rooms)]);
    let building5 = new Building(5,30,30,200,70,"Parking1",TypeOfBuilding.Parking,null);
    let building6 = new Building(6,800,30,200,70,"Parking2",TypeOfBuilding.Parking,null);
    let building7 = new Building(7,800,130,200,70,"Parking3",TypeOfBuilding.Parking,null);
    buildings=[
      building1,building2,building3,building4,building5,building6,building7
    ]
    return buildings;
  }

  public getRooms(): Observable<Array<Room>> {
    let rooms: any;
    
    let room1 = new Room(1, 'Soba za operacije', 'Room description...', 'Pera Peric', 12, TypeOfRoom.OperationRoom,320,30,400,140);
    let room2 = new Room(2, 'Soba za preglede', 'Room description...', 'Dejan Bodiroga', 24, TypeOfRoom.RoomForAppointments,320,260,380,140);
    let room3 = new Room(3, 'Soba za cekanje', 'Room description...', 'Mika Mikic', 12, TypeOfRoom.RoomForAppointments,50,260,270,140);
    let room4 = new Room(4, 'Bolnicka soba', 'Room description...', 'Ziva Zivic', 12, TypeOfRoom.RoomForAppointments,700,260,300,140);
    let room5 = new Room(5, 'Kancelarija', 'Room description...', 'Darko Milicic', 24, TypeOfRoom.RoomForAppointments,50,30,270,140);
    let room6 = new Room(6, 'Kafeterija', 'Room description...', 'Darko Milicic', 24, TypeOfRoom.RoomForAppointments,720,30,280,140);
    let room7 = new Room(7, 'Toalet', 'Room description...', 'Darko Milicic', 24, TypeOfRoom.WC,50,170,150,90);

    rooms = [room1, room2, room3, room4, room5, room6, room7]

    return rooms;
  }
 
}
