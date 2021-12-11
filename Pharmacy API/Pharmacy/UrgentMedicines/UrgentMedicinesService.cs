using Grpc.Core;
using Pharmacy.Model;
using Pharmacy.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UrgentMedicines.Protos;

namespace Pharmacy.UrgentMedicines
{
    public class UrgentMedicinesService : NetGrpcService.NetGrpcServiceBase
    {
        private readonly IMedicineService _medicineService;

        public UrgentMedicinesService(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        public override Task<MessageResponseProto> transfer(MessageProto request, ServerCallContext context)
        {
            Console.WriteLine(request.Message + " " + request.MedicineName + " " + request.MedicineQuantity);
            MessageResponseProto response = new MessageResponseProto();

            Medicine medicine = _medicineService.GetByName(request.MedicineName);
            if (medicine != null && medicine.Name != null)
            {
                if (medicine.Quantity < request.MedicineQuantity)
                {
                    response.Response = "Lek " + request.MedicineName + " ne postoji u navedenoj kolicini (" + request.MedicineQuantity + ").";
                    response.Status = "STATUS ERROR";
                }
                else
                {
                    _medicineService.ReduceMedicineQuantity(medicine.Name, request.MedicineQuantity);
                    response.Response = "Lek " + request.MedicineName + " je prebacen u vasu bolnicu (kolicina: " + request.MedicineQuantity + ").";
                    response.Status = "STATUS OK";
                }
            }
            else
            {
                response.Response = "Lek " + request.MedicineName + " ne postoji u navedenoj apoteci.";
                response.Status = "STATUS ERROR";
            }

            
            //response.Response = "PHARMACY RESPONSE: Lek ce vam biti dostavljen u najkracem mogucem roku.";
            //response.Status = "STATUS OK";
            return Task.FromResult(response);
        }
    }
}
