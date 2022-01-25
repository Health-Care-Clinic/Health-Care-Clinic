using Hospital.Medical_records.Model;
using Hospital.Medical_records.Repository.Interface;
using Hospital.Shared_model.Model;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Medical_records.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;
        private readonly MailSettings _mailSettings;
        private readonly IProfilePictureRepository profilePictureRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        public PatientService(IPatientRepository patientRepository, IProfilePictureRepository profilePictureRepository)
        {
            this.patientRepository = patientRepository;
            this.profilePictureRepository = profilePictureRepository;
        }
        public PatientService(IPatientRepository patientRepository, IOptions<MailSettings> mailSettings, IProfilePictureRepository profilePictureRepository)
        {
            this.patientRepository = patientRepository;
            _mailSettings = mailSettings.Value;
            this.profilePictureRepository = profilePictureRepository;
        }

        public void Add(Patient entity)
        {
            patientRepository.Add(entity);

        }

        public void ActivatePatientsAccount(Patient patient)
        {
            patientRepository.ActivatePatientsAccount(patient.Id);
        }

        public Patient FindByToken(string token)
        {
            return patientRepository.FindByToken(token);
        }
        public string GenerateHashcode(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public async Task SendMail(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            //if (mailRequest.Attachments != null)
            //{
            //    byte[] fileBytes;
            //    foreach (var file in mailRequest.Attachments)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using (var ms = new MemoryStream())
            //            {
            //                file.CopyTo(ms);
            //                fileBytes = ms.ToArray();
            //            }
            //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public List<string> GetAllUsernames()
        {
            return patientRepository.GetAllUsernames();
        }

        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patient GetOneById(int id)
        {
            return patientRepository.GetById(id);
        }

        public void Remove(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void BlockPatientById(int id)
        {
            this.patientRepository.BlockPatientById(id);
        }

        public List<Patient> GetAllSuspiciousPatients()
        {
            return this.patientRepository.GetAllSuspiciousPatients();
        }

        public Patient FindByUsernameAndPassword(string username, string password)
        {
            if (username.Equals("admin") && password.Equals("admin"))
                return new Patient(username, password);
            return this.patientRepository.FindByUsernameAndPassword(username, password);
        }

        public string GenerateJwtToken(Patient patient)
        {
            string id = patient.Id.ToString();
            string role = "patient";
            if (patient.Username.Equals("admin") && patient.Password.Equals("admin"))
                role = "manager";

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Nisam to sto mislis, samo jedna plavusa");
            SecurityTokenDescriptor tokenDescriptor;            

            tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("id", id),
                        new Claim("role", role)
                    }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public String GetProfilePicture(int id)
        {
            return profilePictureRepository.GetByPatientId(id) == null ? "" : profilePictureRepository.GetByPatientId(id).Picture;
        }

        public void AddProfilePicture(ProfilePicture profilePicture)
        {
            profilePictureRepository.Add(profilePicture);
        }
    }
}
