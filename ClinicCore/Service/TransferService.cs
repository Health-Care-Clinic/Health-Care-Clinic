using DTOs;
using Enums;
using Model;
using Storages;
using System;
using System.Collections.Generic;

namespace Service
{
    public class TransferService
    {
        private TransferStorage tfs = new TransferStorage();
        private List<Transfer> AllTransfer { get; set; }

        private static TransferService instance = null;
        public static TransferService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TransferService();
                }
                return instance;
            }
        }

        public TransferService()
        {
           AllTransfer = tfs.GetAll();
           
        }

        public Boolean ScheduleStaticTransfer(StaticTransferAppointmentDTO staticTransfer)
        {
            List<Appointment> RoomsAppointment = AppointmentService.Instance.GetAllAppByTwoRooms(staticTransfer.SourceRoomId, staticTransfer.DestinationRoomId);
            bool checkRoomAppointment = AppointmentService.Instance.CheckAppointment(RoomsAppointment, staticTransfer.StartDate, staticTransfer.EndDate);

            if (checkRoomAppointment)
            {
                CreateAppointmentForEquipmentTransfer(staticTransfer);

            }
            return checkRoomAppointment;
        }

        private void CreateAppointmentForEquipmentTransfer(StaticTransferAppointmentDTO staticTransfer)
        {
            Room sourceRoom = RoomService.Instance.GetRoomById(staticTransfer.SourceRoomId);
            Room destinationRoom = RoomService.Instance.GetRoomById(staticTransfer.DestinationRoomId);

            Equipment equipment = FindEquipment(sourceRoom, staticTransfer.EquipId);
            Transfer transfer = new Transfer(staticTransfer.SourceRoomId, staticTransfer.DestinationRoomId,equipment, staticTransfer.Quantity, staticTransfer.EndDate, false);
            AddTransfer(transfer);

            if (sourceRoom.Type != RoomType.StorageRoom)
            {
                CreateAppointment(staticTransfer, sourceRoom.Id);
            }

            if (destinationRoom.Type != RoomType.StorageRoom)
            {
                CreateAppointment(staticTransfer, destinationRoom.Id);
            }
        }

        private Equipment FindEquipment(Room roomSource,int equipId)
        {
            foreach(Equipment equip in roomSource.Equipment)
            {
                if(equip.EquiptId == equipId)
                {
                    return equip;
                }
            }
            return null;
        }
        

        private static void CreateAppointment(StaticTransferAppointmentDTO staticTransfer,int roomId)
        {
            Appointment appointment = new Appointment(staticTransfer.StartDate, staticTransfer.EndDate, AppointmentType.EquipTransfer, roomId);
            appointment.Reserved = true;
            AppointmentService.Instance.AddAppointment(appointment);
        }

        public void ReduceEquipmentQuantity(Room sourceRoom, Equipment equip, int quantity)
        {
            foreach (Equipment eq in sourceRoom.Equipment)
            {
                if (eq.EquiptId == equip.EquiptId)
                {
                    if (eq.Quantity > quantity)
                    {
                        eq.Quantity = eq.Quantity - quantity;

                    }

                }
            }
            RoomService.Instance.UpdateEquipment(sourceRoom,equip);

        }

        public void ExecuteStaticTransfer(Transfer transfer)
        {

            tfs.Save(AllTransfer);
            Room sourceRoom = RoomService.Instance.GetRoomById(transfer.SourceRoomId);
            Room destinationRoom = RoomService.Instance.GetRoomById(transfer.DestinationRoomId);

            bool isEnoughEquipment = RoomService.Instance.CheckQuantity(sourceRoom, transfer.Equip, transfer.Quantity);

            if (isEnoughEquipment)
            {
                ReduceEquipmentQuantity(sourceRoom, transfer.Equip, transfer.Quantity);

                IncreaseEquipmentQuantity(transfer.Equip, transfer.Quantity, destinationRoom);
            }

           
        }

        private static void IncreaseEquipmentQuantity(Equipment equip, int quantity, Room destinationRoom)
        {
            if (destinationRoom.Equipment == null)
            {
                destinationRoom.Equipment = new List<Equipment>();
            }

            bool exist = false;
            foreach (Equipment eq in destinationRoom.Equipment)
            {
                if (eq.EquiptId == equip.EquiptId)
                {

                    eq.Quantity += quantity;
                    exist = true;
                }
            }

            if (!exist)
            {
                Equipment equipment = new Equipment(equip.EquipType, equip.EquiptId, equip.Name, quantity);
                destinationRoom.Equipment.Add(equipment);
            }
            RoomService.Instance.UpdateEquipment(destinationRoom, equip);
        }



        public void AddTransfer(Transfer transfer)
        {
            AllTransfer.Add(transfer);
            tfs.Save(AllTransfer);
        }

        public void SaveTransfers(List<Transfer> transfers)
        {
            tfs.Save(transfers);
        }

        public List<Transfer> GetAllTransfers()
        {
            return AllTransfer;
        }

    }
}
