using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Pharmacy.Service
{
    public interface IPrescriptionService
    {
        void UploadPdf(Bitmap qr);
    }
}
