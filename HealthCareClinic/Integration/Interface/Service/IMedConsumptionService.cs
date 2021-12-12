using System;
using System.Collections.Generic;
using System.Text;
using ClinicCore.Service;
using Integration.DTO;
using Integration.Pharmacy.Model;

namespace Integration.Interface.Service
{
    public interface IMedConsumptionService : IService<MedicationConsumption>
    {
        void GenerateConsumptionReport(string start, string end);
        List<string> GetConsumptionData(string start, string end);
        DateTime ToDate(string date);
        List<MedicationConsumption> GetConsumedMedicine(DateTime startDate, DateTime endDate);
        List<string> GetFormattedData(List<MedicationConsumption> consumptions);

    }
}
