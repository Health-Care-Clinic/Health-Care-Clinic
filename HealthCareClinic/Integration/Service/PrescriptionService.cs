using System;
using System.Collections.Generic;
using System.Text;
using Integration.DTO;
using Integration.Interface.Service;

namespace Integration.Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private FileTransferService fileTransferService;

        public PrescriptionService()
        {
            fileTransferService = new FileTransferService();
        }

        public void CreatePrescriptionFile(PrescriptionDTO prescriptionDto)
        {
            string content = prescriptionDto.Patient + "\n" + prescriptionDto.Diagnosis + "\n" +
                             prescriptionDto.Medicine + prescriptionDto.Amount.ToString() +
                             "\n" + prescriptionDto.Pharmacy;
            string fileName = "prescription " + prescriptionDto.Patient;
            fileTransferService.CreatePdfDocument(content, "prescription");

        }
    }
}
