
using Hospital.Medical_records.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class ReportAdapter
    {
        public static Report ReportDTOtoReport(ReportDTO dto)
        {
            Report re = new Report();
            re.Id = dto.Id;
            re.Comment = dto.Comment;
            re.Date = StringToDate(dto.Date);

            return re;
        }

        public static ReportDTO ReporttoReportDTO(Report re)
        {
            ReportDTO dto = new ReportDTO();
            dto.Id = re.Id;
            dto.Comment = re.Comment;
            dto.Date = ConvertToString(re.Date);
            return dto;
        }
        private static DateTime StringToDate(string date)
        {
            string[] parts = date.Split("-");
            DateTime newDate = new DateTime(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
            return newDate;
        }
        private static String ConvertToString(DateTime date)
        {
            String dateAsString = date.ToString();

            return dateAsString;
        }
    }

    
}
