using System;
using System.Drawing;
using System.IO;
using Integration.DTO;
using Integration.Interface.Service;
using Integration.Service;
using iTextSharp.text;
using QRCoder;

namespace Integration.Pharmacy.Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private FileTransferService fileTransferService;
        private Bitmap qr;
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

        public void GetPrescriptionQr(PrescriptionDTO prescriptionDto)
        {
            /*QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string content = prescriptionDto.Patient + "\n" + prescriptionDto.Diagnosis + "\n" +
                             prescriptionDto.Medicine + prescriptionDto.Amount.ToString() +
                             "\n" + prescriptionDto.Pharmacy;
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            qr = qrCode.GetGraphic(5);
            qr.Save("image.bmp");
            System.Drawing.Image image = System.Drawing.Image.FromFile("image.bmp");
            Document doc = new Document(PageSize.A4);
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream("image.pdf", FileMode.Create));
            doc.Open();
            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(qr, System.Drawing.Imaging.ImageFormat.Bmp);
            doc.Add(pdfImage);
            doc.Close();*/
            throw new NotImplementedException();
        }

        public void GetPrescriptionPdf()
        {
            /*System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("image.pdf")
            {
                UseShellExecute = true
            });*/
            throw new NotImplementedException();
        }

    }
}
