﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Tendering.Model;
using Hospital_API.DTO;

namespace Hospital_API.Adapter
{
    public class TenderAdapter
    {
        public static Tender TenderDTOToTender(TenderDTO dto)
        {
            Tender tender = new Tender();
            
            tender.Description = dto.Description;
            tender.TenderItems = dto.TenderItems;
            DateRange dateRange = new DateRange(StringToDate(dto.StartDate), StringToDate(dto.EndDate));
            tender.DateRange = dateRange;
            return tender;
        }

        public static TenderDTO TenderToTenderDTO(Tender tender)
        {
            TenderDTO dto = new TenderDTO();
            dto.Id = tender.Id;
            dto.Description = tender.Description;
            dto.TenderItems = tender.TenderItems;
            var formatSpecifier = "o";
            var culture = CultureInfo.GetCultureInfo("en-US");
            dto.StartDate = tender.DateRange.Start.ToString(formatSpecifier, culture);
            dto.EndDate = tender.DateRange.End.ToString(formatSpecifier, culture);
            dto.IsOpen = true;
            DateTime currentDate = DateTime.Now;
            //if(tender.DateRange.Start > currentDate || tender.DateRange.End < currentDate || tender.IsWinningBidChosen == true)
            {
                dto.IsOpen = false;
            }
            dto.OffersNumber = 0;
            return dto;
        }

        public static List<TenderDTO> TendersToTendersDTO(List<Tender> tenders)
        {
            List<TenderDTO> tendersDTO = new List<TenderDTO>();
            foreach(Tender tender in tenders)
            {
                TenderDTO dto = TenderToTenderDTO(tender);
                tendersDTO.Add(dto);
            }
            return tendersDTO;
        }

        private static DateTime StringToDate(string date)
        {
            string[] parts = date.Split("/");
            DateTime newDate = new DateTime(int.Parse(parts[2]), int.Parse(parts[0]), int.Parse(parts[1]));
            return newDate;
        }
    }
}
