using ClinicCore.DTOs;
using Enums;
using Model;
using Storages;
using System;
using System.Collections.Generic;

namespace Service
{
    public class AdvancedRenovationService
    {
        private AdvancedRenovationStorage afs = new AdvancedRenovationStorage();
        public List<AdvancedRenovation> AllAdvancedRenovations { get; set; }

        private static AdvancedRenovationService instance = null;
        public static AdvancedRenovationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdvancedRenovationService();
                }
                return instance;
            }
        }

        private AdvancedRenovationService()
        {
            AllAdvancedRenovations = afs.GetAll();
        }

        public void AddNewAdvancedRenovation(AdvancedRenovation advancedRenovation)
        {
            AllAdvancedRenovations.Add(advancedRenovation);
            afs.Save(AllAdvancedRenovations);
        }

        
        public void RemoveAdvancedRenovation(AdvancedRenovation advancedRenovation)
        {

            AllAdvancedRenovations.Remove(advancedRenovation);
            afs.Save(AllAdvancedRenovations);
        }

        public bool CheckIfTransferIsAfterRenovation(RenovationAppointmentDTO renovationAppointmentDTO )
        {
            bool isAfter = false;
           foreach(AdvancedRenovation advancedRenovation in AllAdvancedRenovations)
            {
                if (DateTime.Compare(renovationAppointmentDTO.DateStart, advancedRenovation.RenovationEnd) > 0)
                {
                    TwoRoomsIdDTO twoRoomsIdDTO = new TwoRoomsIdDTO(renovationAppointmentDTO.RoomIdSource, renovationAppointmentDTO.RoomIdDestination);
                    isAfter = CheckIfTransferRoomsAreInRenovation(twoRoomsIdDTO, advancedRenovation);
                }
            }
            return isAfter;
        }

        private static bool CheckIfTransferRoomsAreInRenovation(TwoRoomsIdDTO twoRoomsIdDTO,AdvancedRenovation advancedRenovation)
        {
            int roomIdSource = twoRoomsIdDTO.RoomIdSource;
            int roomIdDestination = twoRoomsIdDTO.RoomIdDestination;
            bool areInRenovation = false;
            if (advancedRenovation.Type == AdvancedRenovationType.MERGE)
            {
                if (roomIdSource == advancedRenovation.RoomFirst.Id || roomIdSource == advancedRenovation.RoomSecond.Id || roomIdDestination == advancedRenovation.RoomSecond.Id ||
                    roomIdDestination == advancedRenovation.RoomFirst.Id)
                {
                    areInRenovation = true;
                }
            }
            else
            {
                if (roomIdSource == advancedRenovation.RoomFirst.Id || roomIdDestination == advancedRenovation.RoomFirst.Id)
                {
                    areInRenovation = true;
                }
            }
            return areInRenovation;
        }
    }
}
