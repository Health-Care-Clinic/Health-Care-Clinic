using ClinicCore.Storages;
using Hospital.Mapper;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Rooms_and_equipment.Repository
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }

        public List<Equipment> GetEquipmentByRoomId(int id)
        {
            return Context.Set<Equipment>().Where(c => c.RoomId == id).ToList();
        }

        public List<Equipment> GetEquipmentByName(string name)
        {
            return Context.Set<Equipment>().Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public void Change(String equipment, int sourceRoomId, int destinationRoomId, int quantity)
        {
            Equipment.EquipmentType type = Equipment.EquipmentType.Static;

            foreach (Equipment e in GetEquipmentByRoomId(sourceRoomId)) {
                if (e.Name.Equals(equipment))
                {
                    type = e.Type;
                    Context.Set<Equipment>().Find(e.Id).Quantity -= quantity;
                    Save();
                }
            }

            Boolean done = false;
            foreach (Equipment e in GetEquipmentByRoomId(destinationRoomId)) {
                if (e.Name.Equals(equipment))
                {
                    done = true;
                    Context.Set<Equipment>().Find(e.Id).Quantity += quantity;
                    Save();
                }
            }

            if (!done) {
                int i = 0;
                foreach (Equipment e in GetAll().ToList())
                {
                    if (e.Id > i)
                    {
                        i = e.Id;
                    }
                }
                Equipment eq = new Equipment(i+1, equipment, type, quantity, destinationRoomId);
                Add(eq);
            }

            foreach (Equipment e in GetEquipmentByRoomId(sourceRoomId))
            {
                if (e.Name.Equals(equipment) && e.Quantity == 0)
                {
                    Remove(e);
                    break;
                }
            }
        }

        public void ChangeQuantity(int eqId, int newQuantity)
        {
            Context.Set<Equipment>().Find(eqId).Quantity = newQuantity;
            Save();
        }

        public void ChangeRoom(int eqId, int newRoomId)
        {
            Context.Set<Equipment>().Find(eqId).RoomId = newRoomId;
            Save();
        }
    }


}
