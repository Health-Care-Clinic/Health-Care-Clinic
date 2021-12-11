using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Integration.DTO;
using Integration.Interface.Service;
using iTextSharp.text;
using iTextSharp.text.pdf;
using QRCoder;

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

        public Bitmap GetPrescriptionQrPdf(PrescriptionDTO prescriptionDto)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("A", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }
    }
}
