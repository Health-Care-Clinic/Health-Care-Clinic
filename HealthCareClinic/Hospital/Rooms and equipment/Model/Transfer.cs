using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Model
{
    public class Transfer
    {
        public int Id { get; set; }
        public virtual EquipmentForTransfer Equipment { get; set; }
        public virtual RoomsForTransfer RoomsForTransfer { get; set; }
        public virtual DateAndDuration DateAndDuration { get; set; }
        //public DateTime TimeOfCreation { get; set; }

        public Transfer() { }
        public Transfer(int id, Equipment equipment, int sourceID, int destinationID, DateTime date, int duration, DateTime timeOfCreation) {
            Id = id;
            Equipment = new EquipmentForTransfer(equipment.Name, equipment.Quantity);
            RoomsForTransfer = new RoomsForTransfer(sourceID, destinationID);
            DateAndDuration = new DateAndDuration(date, duration);
            //TimeOfCreation = timeOfCreation;
        }

        public List<Transfer> GetTransfersOfSourceAndDestination(List<Transfer> existingTransfers)
        {
            List<Transfer> allTransfersOfSourceAndDestinationRoom = new List<Transfer>();
            foreach (Transfer t in existingTransfers)
            {
                if (t.RoomsForTransfer.SourceRoomId == RoomsForTransfer.SourceRoomId 
                    || t.RoomsForTransfer.DestinationRoomId == RoomsForTransfer.DestinationRoomId 
                    || t.RoomsForTransfer.SourceRoomId == RoomsForTransfer.DestinationRoomId 
                    || t.RoomsForTransfer.DestinationRoomId == RoomsForTransfer.SourceRoomId)
                {
                    allTransfersOfSourceAndDestinationRoom.Add(t);
                }
            }

            return allTransfersOfSourceAndDestinationRoom;
        }

        public DateTime RoundMinutes(DateTime now)
        {
            if (now.Minute < 15)
            {
                return ChangeTime(now.Year, now.Month, now.Day, now.Hour, 15, 0);
            }
            else if (now.Minute < 30)
            {
                return ChangeTime(now.Year, now.Month, now.Day, now.Hour, 30, 0);
            }
            else if (now.Minute < 45)
            {
                return ChangeTime(now.Year, now.Month, now.Day, now.Hour, 45, 0);
            }
            else if (now.Minute < 60)
            {
                return ChangeTime(now.Year, now.Month, now.Day, now.Hour + 1, 0, 0);
            }

            return now;
        }

        public DateTime AddDuration(DateTime transferAndDuration)
        {
            if ((transferAndDuration.Minute + (DateAndDuration.Duration % 60)) < 60)
            {
                return transferAndDuration.AddMinutes(DateAndDuration.Duration % 60);
            }
            else
            {
                DateTime now = transferAndDuration.AddHours(1);
                return ChangeTime(now.Year, now.Month, now.Day, now.Hour, (now.Minute + (DateAndDuration.Duration % 60)) - 60, 0);
            }            
        }

        public DateTime AddTime(DateTime today)
        {
            if (today.Minute < 45)
            {
                today = today.AddMinutes(15);
            }
            else
            {
                if (today.Hour < 23)
                {
                    today = ChangeHours(today.Year, today.Month, today.Day, today.Hour, 0, 0);
                }
                else
                {
                    if (today.Day < DateTime.DaysInMonth(today.Year, today.Month))
                    {
                        today = ChangeDays(today.Year, today.Month, today.Day, 0, 0, 0);
                    }
                    else
                    {
                        if (today.Month < 12)
                        {
                            today = ChangeMonths(today.Year, today.Month, 1, 0, 0, 0);
                        }
                        else
                        {
                            today = today.AddYears(1);
                        }
                    }
                }
            }

            return today;
        }

        private DateTime ChangeTime(int year, int month, int day, int hours, int minutes, int seconds)
        {
            return new DateTime(
                year,
                month,
                day,
                hours,
                minutes,
                seconds);
        }

        private DateTime ChangeMonths(int year, int month, int day, int hours, int minutes, int seconds)
        {
            return new DateTime(
                year,
                month,
                day,
                hours,
                minutes,
                seconds).AddMonths(1);
        }

        private DateTime ChangeDays(int year, int month, int day, int hours, int minutes, int seconds)
        {
            return new DateTime(
                year,
                month,
                day,
                hours,
                minutes,
                seconds).AddDays(1);
        }

        private DateTime ChangeHours(int year, int month, int day, int hours, int minutes, int seconds)
        {
            return new DateTime(
                year,
                month,
                day,
                hours,
                minutes,
                seconds).AddHours(1);
        }
    }
}
