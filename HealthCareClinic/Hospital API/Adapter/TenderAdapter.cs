using System;
using System.Collections.Generic;
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

        private static DateTime StringToDate(string date)
        {
            string[] parts = date.Split("-");
            DateTime newDate = new DateTime(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
            return newDate;
        }
    }
}
