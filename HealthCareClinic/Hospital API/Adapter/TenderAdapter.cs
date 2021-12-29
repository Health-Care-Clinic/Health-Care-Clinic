using System;
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
            DateRange dateRange = new DateRange();
            tender.TenderResponseDescription = dto.Description;
            tender.IsWinningBidChosen = dto.IsWinningBidChosen;
            tender.Medicines = dto.Medicines;
            tender.TotalPrice = new Price();
            tender.DateRange = dateRange;
            tender.TotalPrice.Amount = dto.Price;
            tender.DateRange.Start = StringToDate(dto.StartDate);
            tender.DateRange.End = StringToDate(dto.EndDate);
            return tender;
        }

        public static TenderDTO TenderToTenderDTO(Tender tender)
        {
            TenderDTO dto = new TenderDTO();
            dto.Id = tender.Id;
            dto.Description = tender.TenderResponseDescription;
            dto.IsWinningBidChosen = tender.IsWinningBidChosen;
            dto.Medicines = tender.Medicines;
            dto.Price = tender.TotalPrice.Amount;
            var formatSpecifier = "o";
            var culture = CultureInfo.GetCultureInfo("en-US");
            dto.StartDate = tender.DateRange.Start.ToString(formatSpecifier, culture);
            dto.EndDate = tender.DateRange.End.ToString(formatSpecifier, culture);
            dto.IsOpen = true;
            DateTime currentDate = DateTime.Now;
            if(tender.DateRange.Start > currentDate || tender.DateRange.End < currentDate || tender.IsWinningBidChosen == true)
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
            string[] parts = date.Split("-");
            DateTime newDate = new DateTime(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
            return newDate;
        }
    }
}
