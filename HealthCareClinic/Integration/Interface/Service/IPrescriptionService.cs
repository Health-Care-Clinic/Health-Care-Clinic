﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Integration.DTO;

namespace Integration.Interface.Service
{
    public interface IPrescriptionService
    {
        void CreatePrescriptionFile(PrescriptionDTO prescriptionDto);
        void GetPrescriptionQr(PrescriptionDTO prescriptionDto);
        void GetPrescriptionPdf();
    }
}
