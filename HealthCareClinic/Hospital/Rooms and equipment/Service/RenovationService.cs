using Hospital.Rooms_and_equipment.Model;
using Hospital.Rooms_and_equipment.Repository;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Rooms_and_equipment.Service
{
    public class RenovationService : IRenovationService
    {
        private IRenovationRepository _renovationRepository;
        private ITransferRepository _transferRepository;
        private IAppointmentRepository _appointmentRepository;

        public RenovationService(IRenovationRepository renovationRepository, ITransferRepository transferRepository, IAppointmentRepository appointmentRepository)
        {
            this._renovationRepository = renovationRepository;
            this._transferRepository = transferRepository;
            this._appointmentRepository = appointmentRepository;
        }

        public void Add(Renovation entity)
        {
            _renovationRepository.Add(entity);
        }

        public void Remove(Renovation entity)
        {
            _renovationRepository.Remove(entity);
        }

        public Renovation GetOneById(int id)
        {
            return _renovationRepository.GetById(id);
        }

        public IEnumerable<Renovation> GetAll()
        {
            return _renovationRepository.GetAll();
        }
        public List<DateTime> getFreeTermsForMerge(Renovation renovation)
        {

            List<Transfer> allTransfersOfSourceAndDestinationRoom = getTransfersOfFirstAndSecond(renovation.FirstRoomId, renovation.SecondRoomId);
            List<Renovation> allRenovationsOfFirstAndSecond = getRenovationsOfFirstAndSecond(renovation.FirstRoomId, renovation.SecondRoomId);
            List<Appointment> allAppointmentsOfFirstAndSecond = getAppointmentsOfFirstAndSecond(renovation.FirstRoomId, renovation.SecondRoomId);
            List<DateTime> allAvailableDates = new List<DateTime>();
            DateTime today = DateTime.Now;
            today = roundMinutes(today);
            DateTime todayAndDuration = today.AddDays(Convert.ToInt32(renovation.Duration));
            while (todayAndDuration < renovation.Date)
            {
                Boolean isFree = true;

                isFree = CheckForTransfers(allTransfersOfSourceAndDestinationRoom, isFree, today, todayAndDuration);
                isFree = CheckForRenovation(allRenovationsOfFirstAndSecond, isFree, today, todayAndDuration);
                isFree = CheckForAppointment(allAppointmentsOfFirstAndSecond, isFree, today, todayAndDuration);
               

                if (isFree)
                {
                    allAvailableDates.Add(today);
                }
                if (today.Minute < 45)
                {
                    today = today.AddMinutes(15);

                }
                else
                {
                    if (today.Hour < 23)
                    {
                        today = today.AddHours(1);
                        today = ChangeTime(today.Year, today.Month, today.Day, today.Hour, 0, 0);
                    }
                    else
                    {
                        if (today.Day < DateTime.DaysInMonth(today.Year, today.Month))
                        {
                            today = today.AddDays(1);
                            today = ChangeTime(today.Year, today.Month, today.Day, 0, 0, 0);
                        }
                        else
                        {
                            if (today.Month < 12)
                            {
                                today = today.AddMonths(1);
                                today = ChangeTime(today.Year, today.Month, 1, 0, 0, 0);
                            }
                            else
                            {
                                today = today.AddYears(1);
                            }
                        }
                    }

                }
                todayAndDuration = today.AddDays(Convert.ToInt32(renovation.Duration));

            }
            return allAvailableDates;

        }


        public List<DateTime> getFreeTermsForDivide(Renovation renovation)
        {

            List<Transfer> allTransfersOfSourceAndDestinationRoom = getTransfersOfFirstRoom(renovation.FirstRoomId);
            List<Renovation> allRenovationsOfFirstAndSecond = getRenovationsOfFirstRoom(renovation.FirstRoomId);
            List<Appointment> allApointmentsOfFirst = getAppointmentsOfFirst(renovation.FirstRoomId);
            List<DateTime> allAvailableDates = new List<DateTime>();
            DateTime today = DateTime.Now;
            today = roundMinutes(today);
            DateTime todayAndDuration = today.AddDays(Convert.ToInt32(renovation.Duration));
            while (todayAndDuration < renovation.Date)
            {
                Boolean isFree = true;

                isFree = CheckForTransfers(allTransfersOfSourceAndDestinationRoom, isFree, today, todayAndDuration);
                isFree = CheckForRenovation(allRenovationsOfFirstAndSecond, isFree, today, todayAndDuration);
                isFree = CheckForAppointment(allApointmentsOfFirst, isFree, today, todayAndDuration);

                if (isFree)
                {
                    allAvailableDates.Add(today);
                }
                if (today.Minute < 45)
                {
                    today = today.AddMinutes(15);

                }
                else
                {
                    if (today.Hour < 23)
                    {
                        today = today.AddHours(1);
                        today = ChangeTime(today.Year, today.Month, today.Day, today.Hour, 0, 0);
                    }
                    else
                    {
                        if (today.Day < DateTime.DaysInMonth(today.Year, today.Month))
                        {
                            today = today.AddDays(1);
                            today = ChangeTime(today.Year, today.Month, today.Day, 0, 0, 0);
                        }
                        else
                        {
                            if (today.Month < 12)
                            {
                                today = today.AddMonths(1);
                                today = ChangeTime(today.Year, today.Month, 1, 0, 0, 0);
                            }
                            else
                            {
                                today = today.AddYears(1);
                            }
                        }
                    }

                }
                todayAndDuration = today.AddDays(Convert.ToInt32(renovation.Duration));

            }
            return allAvailableDates;

        }

        private List<Appointment> getAppointmentsOfFirstAndSecond(int firstRoomId, int secondRoomId)
        {
            List<Appointment> existingAppointments = _appointmentRepository.GetAll().ToList();
            List<Appointment> allAppointmentOfSourceAndDestinationRoom = new List<Appointment>();
            foreach (Appointment tran in existingAppointments)
            {
                if (tran.RoomId == firstRoomId || tran.RoomId == secondRoomId)
                {
                    allAppointmentOfSourceAndDestinationRoom.Add(tran);
                }
            }
            return allAppointmentOfSourceAndDestinationRoom;
        }

        private List<Appointment> getAppointmentsOfFirst(int firstRoomId)
        {
            List<Appointment> existingAppointments = _appointmentRepository.GetAll().ToList();
            List<Appointment> allAppointmentOfSourceAndDestinationRoom = new List<Appointment>();
            foreach (Appointment tran in existingAppointments)
            {
                if (tran.RoomId == firstRoomId)
                {
                    allAppointmentOfSourceAndDestinationRoom.Add(tran);
                }
            }
            return allAppointmentOfSourceAndDestinationRoom;
        }
        private List<Transfer> getTransfersOfFirstAndSecond(int firstRoomId, int secondRoomId)
        {
            List<Transfer> existingTransfers = _transferRepository.GetAll().ToList();
            List<Transfer> allTransfersOfSourceAndDestinationRoom = new List<Transfer>();
            foreach (Transfer tran in existingTransfers)
            {
                if (tran.RoomsForTransfer.SourceRoomId == firstRoomId || tran.RoomsForTransfer.DestinationRoomId == secondRoomId || tran.RoomsForTransfer.SourceRoomId == secondRoomId || tran.RoomsForTransfer.DestinationRoomId == firstRoomId)
                {
                    allTransfersOfSourceAndDestinationRoom.Add(tran);
                }
            }
            return allTransfersOfSourceAndDestinationRoom;
        }

        private List<Transfer> getTransfersOfFirstRoom(int firstRoomId)
        {
            List<Transfer> existingTransfers = _transferRepository.GetAll().ToList();
            List<Transfer> allTransfersOfFirst = new List<Transfer>();
            foreach (Transfer tran in existingTransfers)
            {
                if (tran.RoomsForTransfer.SourceRoomId == firstRoomId || tran.RoomsForTransfer.DestinationRoomId == firstRoomId)
                {
                    allTransfersOfFirst.Add(tran);
                }
            }
            return allTransfersOfFirst;
        }

        private List<Renovation> getRenovationsOfFirstAndSecond(int firstRoomId, int secondRoomId)
        {
            List<Renovation> existingRenovations = GetAll().ToList();
            List<Renovation> allRenovationsOfFirstAndSecondRoom = new List<Renovation>();
            foreach (Renovation ren in existingRenovations)
            {
                if (ren.FirstRoomId == firstRoomId || ren.SecondRoomId == secondRoomId || ren.FirstRoomId == secondRoomId || ren.SecondRoomId == firstRoomId)
                {
                    allRenovationsOfFirstAndSecondRoom.Add(ren);
                }
            }
            return allRenovationsOfFirstAndSecondRoom;
        }

        private List<Renovation> getRenovationsOfFirstRoom(int firstRoomId)
        {
            List<Renovation> existingRenovations = GetAll().ToList();
            List<Renovation> allRenovationsOfFirst = new List<Renovation>();
            foreach (Renovation ren in existingRenovations)
            {
                if (ren.FirstRoomId == firstRoomId || ren.SecondRoomId == firstRoomId)
                {
                    allRenovationsOfFirst.Add(ren);
                }
            }
            return allRenovationsOfFirst;
        }

        private DateTime roundMinutes(DateTime now)
        {
            if (now.Minute < 15)
            {
                now = ChangeTime(now.Year, now.Month, now.Day, now.Hour, 15, 0);
            }
            else if (now.Minute < 30)
            {
                now = ChangeTime(now.Year, now.Month, now.Day, now.Hour, 30, 0);
            }
            else if (now.Minute < 45)
            {
                now = ChangeTime(now.Year, now.Month, now.Day, now.Hour, 45, 0);
            }
            else if (now.Minute < 60)
            {
                now = ChangeTime(now.Year, now.Month, now.Day, now.Hour + 1, 0, 0);
            }
            return now;
        }
        private DateTime addDuration(DateTime now, int duration)
        {
            if ((now.Minute + (duration % 60)) < 60)
            {
                now = now.AddMinutes(duration % 60);
            }
            else
            {
                now = now.AddHours(1);
                now = ChangeTime(now.Year, now.Month, now.Day, now.Hour, (now.Minute + (duration % 60)) - 60, 0);
            }
            return now;
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

        public List<Renovation> GetRoomRenovations(int id)
        {
            List<Renovation> roomRenovations = new List<Renovation>();
            foreach (Renovation renovation in GetAll())
            {
                if (renovation.SecondRoomId == id || renovation.FirstRoomId == id)
                    roomRenovations.Add(renovation);
            }
            return roomRenovations;
        }

        public bool CheckIfRenovationCancellable(int id)
        {
            foreach (Renovation renovation in GetAll())
            {
                if (renovation.Id == id && DateTime.Now.AddHours(24) <= renovation.Date)
                    return true;
            }
            return false;
        }

        public void RemoveById(int id)
        {
            _renovationRepository.RemoveById(id);
        }

        public Boolean CheckForTransfers(List<Transfer> allTransfersOfSourceAndDestinationRoom, Boolean isFree, DateTime today, DateTime todayAndDuration)
        {
            foreach (Transfer t in allTransfersOfSourceAndDestinationRoom)
            {
                DateTime transferAndDuration = t.DateAndDuration.Date.AddHours(Convert.ToInt32(t.DateAndDuration.Duration) / 60);
                transferAndDuration = addDuration(transferAndDuration, t.DateAndDuration.Duration);
                if (t.DateAndDuration.Date <= today && today <= transferAndDuration)
                {
                    isFree = false;
                }
                if (t.DateAndDuration.Date <= todayAndDuration && todayAndDuration <= transferAndDuration)
                {
                    isFree = false;
                }
                if (today <= t.DateAndDuration.Date && t.DateAndDuration.Date <= todayAndDuration)
                {
                    isFree = false;
                }

            }
            return isFree;
        }

        public Boolean CheckForRenovation(List<Renovation> allRenovationsOfFirstAndSecond,Boolean isFree, DateTime today, DateTime todayAndDuration)
        {
            foreach (Renovation r in allRenovationsOfFirstAndSecond)
            {
                DateTime renovationAndDuration = r.Date.AddDays(Convert.ToInt32(r.Duration));
                if (r.Date <= today && today <= renovationAndDuration)
                {
                    isFree = false;
                }
                if (r.Date <= todayAndDuration && todayAndDuration <= renovationAndDuration)
                {
                    isFree = false;
                }
                if (today <= r.Date && r.Date <= todayAndDuration)
                {
                    isFree = false;
                }

            }
            return isFree;
        }

        public Boolean CheckForAppointment(List<Appointment> allAppointmentsOfFirstAndSecond, Boolean isFree, DateTime today, DateTime todayAndDuration)
        {
            foreach (Appointment r in allAppointmentsOfFirstAndSecond)
            {
                DateTime appointmentAndDuration = addDuration(r.Date, 30);
                if (r.Date <= today && today <= appointmentAndDuration)
                {
                    isFree = false;
                }
                if (r.Date <= todayAndDuration && todayAndDuration <= appointmentAndDuration)
                {
                    isFree = false;
                }
                if (today <= r.Date && r.Date <= todayAndDuration)
                {
                    isFree = false;
                }

            }
            return isFree;
        }

        public int FindAvailableId()
        {
            int id = 0;
            List<Renovation> renovations = GetAll().ToList();

            foreach (Renovation r in renovations)
            {
                if (r.Id > id)
                {
                    id = r.Id;
                }
            }

            return id + 1;
        }

        public int FindAvailableYear()
        {
            int year = 2022;
            List<Renovation> renovations = GetAll().ToList();

            foreach (Renovation r in renovations)
            {
                if (r.Date.Year > year)
                {
                    year = r.Date.Year;
                }
            }

            return year + 1;
        }
    }
}
