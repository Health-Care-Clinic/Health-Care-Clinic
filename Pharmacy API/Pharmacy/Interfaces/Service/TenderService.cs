using System;
using System.Collections.Generic;
using System.Linq;
using Pharmacy.Interfaces.Repository;
using Pharmacy.Prescriptions.Model;
using Pharmacy.Tendering.Model;

namespace Pharmacy.Interfaces.Service
{
    public class TenderService : ITenderService
    {

        private readonly ITenderRepository _tenderRepository;

        public TenderService(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }
        public void Add(Tender entity)
        {
            _tenderRepository.Add(entity);
            _tenderRepository.Save();
        }

        public IEnumerable<Tender> GetAll()
        {
            return _tenderRepository.GetAll();
        }

        public TenderResponse GetDataForTender(Tender tender)
        {
            throw new NotImplementedException();
        }

        public Tender GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Tender entity)
        {
            throw new NotImplementedException();
        }
        /*
        public Tender GetDataForTender(Tender tenderRequest)
        {
            List<Medicine> medicineRequested = tenderRequest.Medicines;
          
            List<Medicine> availableMedicines = GetAvailableMedicine(medicineRequested);
            return CreatetenderResponse(availableMedicines); ;
        }

        private static Tender CreatetenderResponse(List<Medicine> availableMedicines)
        {
            Tender tender = new Tender();
            if (!availableMedicines.Contains(null))
            {
                CreatePostiveTenderResponse(tender, availableMedicines);
            }
            else
            {
                CreateNegativeTenderResponse(tender, availableMedicines);
            }
            return tender;
        }

        private static void CreatePostiveTenderResponse(Tender tender, List<Medicine> availableMedicines)
        {
            double total = availableMedicines.Sum(x => x.Price * x.Quantity);
            tender.Medicines = availableMedicines;
            tender.TotalPrice = total;
            tender.TenderResponseDescription = "Svi zahtjevi su ispunjeni";
        }

        private static void CreateNegativeTenderResponse(Tender tender, List<Medicine> availableMedicines)
        {
           
            tender.Medicines = availableMedicines;
            tender.TotalPrice = 0;
            tender.TenderResponseDescription = "Apoteka trenutno nema dostupne sve lijekove ili trazene kolicine";
        }

        private List<Medicine> GetAvailableMedicine(List<Medicine> medicineRequested)
        {
            List<Medicine> availableMedicines = new List<Medicine>();
            foreach (Medicine med in medicineRequested)
            {
                CheckIfMedicineIsAvailable(availableMedicines, med);
            }

            return availableMedicines;
        }

        private void CheckIfMedicineIsAvailable(List<Medicine> availableMedicines, Medicine med)
        {
            List<Medicine> medicines = _medicineService.SearchMedicine(med.Name, med.Manufacturer, med.Weight).ToList();
            Console.WriteLine(medicines.Count);
            if (medicines.Count == 1)
            {
                CheckMedicineQuantity(availableMedicines, med, medicines);
            }
            else
            {
                availableMedicines.Add(null);
            }
        }

        private static void CheckMedicineQuantity(List<Medicine> availableMedicines, Medicine med, List<Medicine> medicines)
        {
            if (!medicines[0].CheckQuantity(med.Quantity))
            {
                availableMedicines.Add(null);
            }
            else
            {
                availableMedicines.Add(medicines[0]);
            }
        }*/
    }
}
