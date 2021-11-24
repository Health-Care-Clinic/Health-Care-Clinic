using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Model
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        //public List<IFormFile> Attachments { get; set; }


        public MailRequest(string confirmationLink, string name, string email)
        {
            ToEmail = email;
            Subject = "Activation mail";
            Body = "Hi, " + name + ". Welcome to our hospital service. We hope that you will be satisfied with our services. In order to activate your account click on this link: " + confirmationLink;
        }    
    }
}
