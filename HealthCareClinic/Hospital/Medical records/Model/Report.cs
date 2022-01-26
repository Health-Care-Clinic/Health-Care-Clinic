using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital.Medical_records.Model
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public virtual Appointment Appointment { get; set; }

        public Report()
        {
        }

        public Report(int id, string comment, DateTime date)
        {
            Id = id;
            Comment = comment;
            Date = date;
        }
    }
}
