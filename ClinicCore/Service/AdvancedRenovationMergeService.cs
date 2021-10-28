using ClinicCore.Service;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Hospital_IS.Service
{
    public class AdvancedRenovationMergeService : IAdvancedRenovationService
    {
       
        public void ExecuteAdvancedRoomRenovation(AdvancedRenovation advancedRenovation)
        {
            RoomService.Instance.RemoveRoom(advancedRenovation.RoomFirst);
            RoomService.Instance.RemoveRoom(advancedRenovation.RoomSecond);
            Room room = new Room(advancedRenovation.RenovationResultRoom.RoomNumber, advancedRenovation.RenovationResultRoom.RoomFloor, advancedRenovation.RenovationResultRoom.SurfaceArea,
                0, advancedRenovation.RenovationResultRoom.Type);
            AddEquipmentFromBothRoom(advancedRenovation, room);

            RoomService.Instance.AddRoom(room);
        }

        private static void AddEquipmentFromBothRoom(AdvancedRenovation advancedRenovation, Room room)
        {
            List<Equipment> equipment = new List<Equipment>();
            equipment.AddRange(advancedRenovation.RoomFirst.Equipment);
            equipment.AddRange(advancedRenovation.RoomFirst.Equipment);
            room.Equipment = equipment;
        }

        public void MakeAdvancedRenovation(AdvancedRenovation advancedRenovation)
        {
            AdvancedRenovationService.Instance.AddNewAdvancedRenovation(advancedRenovation);

            CancelDocAppFromBothRoom(advancedRenovation);
            CancelClassicAppFromBothRoom(advancedRenovation);
            MarkTransferAsCompleted(advancedRenovation.RenovationStart);
        }

        private void CancelClassicAppFromBothRoom(AdvancedRenovation advancedRenovation)
        {
            CancelClassicAppAfterDateEnd(advancedRenovation.RoomFirst.Id, advancedRenovation.RenovationEnd);
            CancelClassicAppAfterDateEnd(advancedRenovation.RoomSecond.Id, advancedRenovation.RenovationEnd);
          

        }

        private void MarkTransferAsCompleted(DateTime renovationStart)
        {
            List<Transfer> transfers = TransferService.Instance.GetAllTransfers();
            foreach (Transfer transfer in transfers)
            {
                if(DateTime.Compare(transfer.TransferEnd,renovationStart ) > 0)
                {
                    transfer.IsMade = true;
                }
            }
            TransferService.Instance.SaveTransfers(transfers);
        }

        private void CancelClassicAppAfterDateEnd(int roomId, DateTime renovationEnd)
        {
            List<Appointment> appointments = new List<Appointment>();
            AppointmentService.Instance.GetAllClassicAppointments(roomId, appointments);
            for (int i = 0; i < appointments.Count; i++)
            {               
                if (DateTime.Compare(renovationEnd, appointments[i].AppointmentStart) <= 0)
                {                  
                    AppointmentService.Instance.RemoveAppointment(appointments[i]);
                }
            }
        }

        private void CancelDocAppFromBothRoom(AdvancedRenovation advancedRenovation)
        {
            CanacelDocAppAfterDateEnd(advancedRenovation.RoomFirst.Id, advancedRenovation.RenovationEnd);
            CanacelDocAppAfterDateEnd(advancedRenovation.RoomSecond.Id, advancedRenovation.RenovationEnd);
        }

        public void CanacelDocAppAfterDateEnd(int roomId, DateTime dateEnd)
        {
            List<DoctorAppointment> doctorAppointments = DoctorAppointmentService.Instance.GetAllByRoom(roomId);

            for (int i = 0; i < doctorAppointments.Count; i++)
            {
                if (DateTime.Compare(dateEnd, doctorAppointments[i].AppointmentStart) <= 0)
                {
                    NotificationService.Instance.SendAppointmentCancelationNotification(doctorAppointments[i]);
                    DoctorAppointmentService.Instance.RemoveAppointment(doctorAppointments[i]);
                }
            }

        }    

       
    }
}
