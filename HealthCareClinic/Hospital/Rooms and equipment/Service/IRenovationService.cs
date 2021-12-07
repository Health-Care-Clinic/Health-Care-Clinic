using ClinicCore.Service;
using Hospital.Rooms_and_equipment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Rooms_and_equipment.Service
{
    public interface IRenovationService: IService<Renovation>
    {
        public List<DateTime> getFreeTermsForMerge(Renovation renovation);
        public List<DateTime> getFreeTermsForDivide(Renovation renovation);
    }
}
