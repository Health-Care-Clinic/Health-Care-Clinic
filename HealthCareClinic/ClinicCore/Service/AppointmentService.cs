using ClinicCore.DTOs;
using ClinicCore.Service;
using Model;
using Storages;
using System;
using System.Collections.Generic;

namespace Service
{
    public class AppointmentService
    {
        private ClassicAppointmentStorage afs = new ClassicAppointmentStorage();
        public List<Appointment> AllAppointments { get; set; }

        public int MaxId;

        private static AppointmentService instance = null;
        public static AppointmentService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppointmentService();
                }
                return instance;
            }
        }

        private AppointmentService()
        {
            AllAppointments = afs.GetAll();
        }

        public List<Appointment> GetAllAppByTwoRooms(int roomIdSource, int roomIdDestination)
        {
            List<Appointment> allApointments = new List<Appointment>();

            allApointments = GetAllApointmentsByRoomId(roomIdSource);

            allApointments.AddRange(GetAllApointmentsByRoomId(roomIdDestination));

            return allApointments;

        }

        public List<Appointment> GetAllApointmentsByRoomId(int roomID)
        {
            List<Appointment> allAppointments = new List<Appointment>();
            GetAllDoctorsAppointment(roomID, allAppointments);

            GetAllClassicAppointments(roomID, allAppointments);

            return allAppointments;

        }

        public void GetAllClassicAppointments(int roomId, List<Appointment> allApointments)
        {
           
            foreach (Appointment ap in GetAppByRoom(roomId))
            {
                allApointments.Add(ap);
            }
        }

        private void GetAllDoctorsAppointment(int roomId, List<Appointment> allApointments)
        {
            foreach (Appointment ap in DoctorAppointmentService.Instance.GetAllByRoom(roomId))
            {
                allApointments.Add(ap);
            }
        }


        public bool MakeRenovationAppointment(Appointment appointment)
        {
            List<Appointment> appointments = new List<Appointment>();

            appointments = GetAllApointmentsByRoomId(appointment.Room);

            bool isPossible = CheckAppointment(appointments, appointment.AppointmentStart, appointment.AppointmentEnd);

            if (isPossible)
            {

                appointment.Reserved = true;
                AddAppointment(appointment);
            }

            return isPossible;
        }

        public List<RenovationReportDTO> FindAllRenovationAppBetweeenDates(RenovationDTO renovationDTO)
        {
            List<RenovationReportDTO> renovationReports = new List<RenovationReportDTO>();
            foreach (Appointment app in AllAppointments)
            {
                if (app.Type == renovationDTO.AppType && app.AppointmentStart >= renovationDTO.DateStart && app.AppointmentStart <= renovationDTO.DateEnd)
                {
                    AddRenovationReport(renovationReports, app);
                }
                  
            }

            return renovationReports;
        }

        public void RemoveAppointment(Appointment appointment)
        {
            foreach(Appointment app in AllAppointments)
            {
                if(app.Id == appointment.Id)
                {
                    
                    AllAppointments.Remove(app);
                    afs.SaveAppointment(AllAppointments);
                    break;
                }
            }
        }

        private static void AddRenovationReport(List<RenovationReportDTO> renovationReports, Appointment app)
        {
            int roomNumber = RoomService.Instance.GetRoomNumber(app.Room);
            RenovationReportDTO renovationReportDTO = new RenovationReportDTO(app.AppointmentStart, app.AppointmentEnd, roomNumber, app.AppointmentCause);
            renovationReports.Add(renovationReportDTO);
        }

        public bool MakeRenovationAppointmentForRoomMerge(Appointment firstRoomAppointment,Appointment secondRoomAppointment)
        {
            bool isPossibleForFirstRoom = CheckIfPossibilityForRenovation(firstRoomAppointment);

            bool isPossibleForSecondRoom = CheckIfPossibilityForRenovation(secondRoomAppointment);

            if (isPossibleForFirstRoom && isPossibleForSecondRoom)
            {
                AddRenovationAppointment(firstRoomAppointment);
                AddRenovationAppointment(secondRoomAppointment);

            }

            return isPossibleForFirstRoom && isPossibleForSecondRoom;
        }

        private void AddRenovationAppointment(Appointment appointment)
        {
            appointment.Reserved = true;
            AddAppointment(appointment);
        }

        private bool CheckIfPossibilityForRenovation(Appointment firstRoomAppointment)
        {
            List<Appointment> appointments = new List<Appointment>();

            appointments = GetAllApointmentsByRoomId(firstRoomAppointment.Room);

            bool isPossible = CheckAppointment(appointments, firstRoomAppointment.AppointmentStart, firstRoomAppointment.AppointmentEnd);
            return isPossible;
        }

        public List<Appointment> GetAppByRoom(int roomId)
        {
            List<Appointment> roomAppointment = new List<Appointment>();


           
            foreach (Appointment appointment in AllAppointments)
            {
                
                if (appointment.Room == roomId)
                {
                    roomAppointment.Add(appointment);

                }
            }
            return roomAppointment;
        }

        public bool CheckAppointment(List<Appointment> appointments, DateTime start, DateTime end)
        {
            bool isFree = true;
            foreach (Appointment appointment in appointments)
            {
                
                bool between = IsBetweenDates(start, end, appointment);
                if (between || (start <= appointment.AppointmentStart && end >= appointment.AppointmentEnd))
                {
                    isFree = false;
                    break;
                }

            }
            return isFree;
        }

        private bool IsBetweenDates(DateTime start, DateTime end, Appointment appointment)
        {
            return (start > appointment.AppointmentStart && start < appointment.AppointmentEnd) || (end > appointment.AppointmentStart && end < appointment.AppointmentEnd);
        }

        public void AddAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                return;
            }

            if (AllAppointments == null)
            {
                AllAppointments = new List<Appointment>();

            }

            if (!AllAppointments.Contains(appointment))
            {
                appointment.Id = GenerateAppointmentID();
                AllAppointments.Add(appointment);
                afs.SaveAppointment(AllAppointments);
              
            }
        }


        public void FindMaxID()
        {
            List<Appointment> appointments = new List<Appointment>(DoctorAppointmentService.Instance.AllAppointments);
            appointments.AddRange(AllAppointments);
            int max = 0;
            foreach (Appointment appointment in appointments)
            {
                if (max < appointment.Id)
                {
                    max = appointment.Id;
                }
            }

            MaxId = max;
        }

        public int GenerateAppointmentID()
        {
            FindMaxID();
            ++MaxId;
            return MaxId;
        }
        public void CancelAllAppFromRoom(int roomId)
        {
            CancelClassicAppointments(roomId);
            CanacelDocAppointments(roomId);
        }

        private void CancelClassicAppointments(int roomId)
        {
            List<Appointment> appointments = new List<Appointment>();
            AppointmentService.Instance.GetAllClassicAppointments(roomId, appointments);
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].Room == roomId)
                {
                    AppointmentService.Instance.RemoveAppointment(appointments[i]);
                }
            }
        }

        private void CanacelDocAppointments(int roomId)
        {
            List<DoctorAppointment> doctorAppointments = DoctorAppointmentService.Instance.GetAllByRoom(roomId);

            for (int i = 0; i < doctorAppointments.Count; i++)
            {
                if (doctorAppointments[i].Room == roomId)
                {
                    NotificationService.Instance.SendAppointmentCancelationNotification(doctorAppointments[i]);
                    DoctorAppointmentService.Instance.RemoveAppointment(doctorAppointments[i]);
                }
            }

        }

    }
}
