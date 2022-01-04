using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class OnCallShift
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }

        public OnCallShift()
        {

        }
        public OnCallShift(int id, DateTime date, int doctorId)
        {
            Id = id;
            Date = date;
            DoctorId = doctorId;
        }
    }
}
