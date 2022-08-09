using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.DTO
{
    public class ReportDTO
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }

        public ReportDTO()
        {
        }

        public ReportDTO(int id, string comment, string date)
        {
            Id = id;
            Comment = comment;
            Date = date;
        }
    }
}
