using System;
using System.Collections.Generic;
using System.Linq;
using Integration.Interface.Repository;
using Integration.Interface.Service;
using Integration.Pharmacy.Model;
using Integration.Service;

namespace Integration.Pharmacy.Service
{
    public class MedConsumptionService : IMedConsumptionService
    {
        private readonly IMedConsumptionRepository _medConsumptionRepository;
        private FileTransferService fileTransferService;

        public MedConsumptionService(IMedConsumptionRepository medConsumptionRepository)
        {
            _medConsumptionRepository = medConsumptionRepository;
            fileTransferService = new FileTransferService();
        }

        public void Add(MedicationConsumption entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(MedicationConsumption entity)
        {
            throw new NotImplementedException();
        }

        public MedicationConsumption GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MedicationConsumption> GetAll()
        {
            throw new NotImplementedException();
        }

        public void GenerateConsumptionReport(string start, string end)
        {
            List<string> output = GetConsumptionData(start, end);
            string filename = "Report";
            string content = "";
            foreach (string o in output)
            {
                content += o + "\n";
            }
            fileTransferService.CreatePdfDocument(content, filename);
            fileTransferService.UploadFile(filename);
        }

        public List<string> GetConsumptionData(string start, string end)
        {
            Console.WriteLine(start);
            Console.WriteLine(end);
            DateTime startDate = ToDate(start);
            DateTime endDate = ToDate(end);
            List<MedicationConsumption> consumptions = GetConsumedMedicine(startDate, endDate);
            List<string> output = GetFormattedData(consumptions);
            return output;

        }

        public DateTime ToDate(string date)
        {
            string[] parts = date.Split("-");
            DateTime newDate = new DateTime(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
            return newDate;
        }

        public List<MedicationConsumption> GetConsumedMedicine(DateTime startDate, DateTime endDate)
        {
            List<MedicationConsumption> consumptions = _medConsumptionRepository.GetAll().ToList();
            List<MedicationConsumption> consumptionsForPeriod = new List<MedicationConsumption>();

            foreach (MedicationConsumption consumption in _medConsumptionRepository.GetAll())
            {
                if (consumption.Date >= startDate && consumption.Date <= endDate)
                {
                    consumptionsForPeriod.Add(consumption);
                }
            }

            return consumptionsForPeriod;
        }

        public List<string> GetFormattedData(List<MedicationConsumption> consumptions)
        {
            List<string> formattedData = new List<string>();
            foreach (MedicationConsumption consumption in consumptions)
            {
                formattedData.Add("NAME: " + consumption.Name + ", AMOUNT: " + consumption.Amount.ToString() + ", DATE: " + consumption.Date.Date.ToString());
            }

            return formattedData;
        }
    }
}
