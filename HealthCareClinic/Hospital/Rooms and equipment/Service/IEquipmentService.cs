﻿using ClinicCore.Service;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Service
{
    public interface IEquipmentService : IService<Equipment>
    {
        public List<Equipment> GetEquipmentByRoomId(int id);
        public List<Equipment> GetEquipmentByName(string name);
    }
}
