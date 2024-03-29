﻿using System;
using System.Threading.Tasks;
using Grpc.Core;
using Integration.Interface.Service;
using Integration.Model;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using UrgentMedicines.Protos;

namespace Integration_API.Controller.UrgentMedicines
{
    [Route("hospital/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UrgentMedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public UrgentMedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpPost]
        public async Task<IActionResult> UrgentMedicineRequest([FromBody] Medicine medicine)
        {
            Channel channel = new Channel("localhost:8787", ChannelCredentials.Insecure);
            NetGrpcService.NetGrpcServiceClient client = new NetGrpcService.NetGrpcServiceClient(channel);

            MessageResponseProto response = await client.transferAsync(new MessageProto() { Message = "HOSPITAL REQUEST: ", MedicineName = medicine.Name, MedicineQuantity = medicine.Quantity });
            Console.WriteLine(response.Response + " | " + response.Status);
            if (response.Status == "STATUS OK")
            {
                var restClient = new RestClient("http://localhost:52844");
                var request = new RestRequest("api/medicine/add");
                request.AddQueryParameter("medicineName", medicine.Name);
                request.AddQueryParameter("quantity", medicine.Quantity.ToString());
                IRestResponse restResponse = restClient.Post(request);
            }

            return Ok(response.Response);
        }
    }
}
