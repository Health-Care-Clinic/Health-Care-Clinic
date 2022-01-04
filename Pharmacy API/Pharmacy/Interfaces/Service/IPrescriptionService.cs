using System.Drawing;

namespace Pharmacy.Interfaces.Service
{
    public interface IPrescriptionService
    {
        void UploadPdf(Bitmap qr);
    }
}
