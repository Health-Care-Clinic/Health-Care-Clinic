using Hospital.Shared_model.Interface;
using Hospital.Shared_model.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }


        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Uspesno ste se registrovali. Uskoro ce vam stici e-mail sa aktivacionim linkom.
        // Postovani, dobrodosli u bolnicu. Nadamo se da cete biti zadovoljni nasim uslugama. Da biste aktivirali svoj nalog kliknite na sledeci link (/api/activate?token=........)
    }
}
