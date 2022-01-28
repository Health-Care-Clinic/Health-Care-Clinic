using Hospital.Mapper;
using Hospital.Medical_records.Model;
using Hospital.Medical_records.Repository;
using Hospital.Medical_records.Service;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital.Shared_model.Service;
using Hospital_API.Controller;
using Hospital_API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HospitalIntegrationTests.Patient_portal
{
    public class PrescriptionTest
    {
        [Fact]
        public void Get_all_prescriptons_for_patient_from_database()
        {
            var options = CreateStubDatabase();

            using (var context = new HospitalDbContext(options))
            {
                DoctorRepository doctorRepository = new DoctorRepository(context);
                DoctorService doctorService = new DoctorService(doctorRepository);

                AllergenRepository allergenRepository = new AllergenRepository(context);
                AllergenService alergenService = new AllergenService(allergenRepository);

                PatientRepository patientRepository = new PatientRepository(context);
                PatientService patientService = new PatientService(patientRepository);

                PrescriptionRepository prescriptionRepository = new PrescriptionRepository(context);
                PrescriptionService prescriptionService = new PrescriptionService(prescriptionRepository);

                PatientController patientRegistrationController = new PatientController(alergenService, doctorService, prescriptionService, patientService);

                int patientId = 1;
                OkObjectResult response = patientRegistrationController.GetAllPrescriptionsForPatient(patientId) as OkObjectResult;

                response.Value.ShouldBeAssignableTo<List<PrescriptionPatientDTO>>();

                List<PrescriptionPatientDTO> prescriptions = response.Value as List<PrescriptionPatientDTO>;
                foreach (Prescription prescription in context.Prescriptions)
                {
                    context.Prescriptions.Remove(prescription);
                    context.SaveChanges();
                }

                Assert.Equal(3, prescriptions.Count());
                Assert.IsType<List<PrescriptionPatientDTO>>(prescriptions);
            }
        }
        private DbContextOptions<HospitalDbContext> CreateStubDatabase()
        {
            var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(databaseName: "Prescriptions")
            .Options;

            using (var context = new HospitalDbContext(options))
            {

                Prescription prescription1 = new Prescription (1, "Uzimati 1 put dnevno do poboljsanja", "Panklav",300,new DateTime(2022, 1, 22, 7, 0, 0), 1,  10 );
                Prescription prescription2 = new Prescription (2, "Uzimati 2 put dnevno do poboljsanja", "Brufen",  200, new DateTime(2022, 1, 12, 8, 0, 0), 1,25 );
                Prescription prescription3 = new Prescription (3, "Uzimati 3 put dnevno do poboljsanja", "Kafetin",  400,  new DateTime(2022, 1, 05, 9, 0, 0),  1, 26 );
                Patient patient1 = new Patient(1, "Petar", "Petrovic", "male", "A", new System.DateTime(2005, 09, 11), "Bogoboja Atanackovica 15", "0634556665", "petar@gmail.com", "petar", "petarp001", "Miki", null, "Employed", true)
                { DoctorId = 1 };
                Doctor doctor1 = new Doctor(1, "Nikola", "Nikolic", "male", new System.DateTime(1981, 05, 06), 80000.0, "Brace Radica 15", "0697856665", "nikolanikolic@gmail.com", "nikola", "nikola",
                    new System.DateTime(2021, 06, 10), null, "General medicine", 1);

                Doctor doctor2 = new Doctor(2, "Marko", "Radic", "male", new System.DateTime(1986, 04, 06), 80000.0, "Bogoboja Atanackovica 5", "0697856665", "markoradic@gmail.com", "marko", "marko",
                     new System.DateTime(2020, 06, 07), null, "General medicine", 2);

                Doctor doctor3 = new Doctor(3, "Jozef", "Sivc", "male", new System.DateTime(1971, 06, 09), 80000.0, "Bulevar Oslobodjenja 45", "0697856665", "jozika@gmail.com", "jozef", "jozef",
                     new System.DateTime(2011, 03, 10), null, "General medicine", 3);
                Appointment appointment1 = new Appointment(10, 1, 2, 2, false, true, new DateTime(2022, 1, 05, 9, 0, 0), 10, 1);
                Appointment appointment2 = new Appointment(25, 1, 2, 1, false, true, new DateTime(2022, 1, 22, 7, 0, 0), 25, 2);
                Appointment appointment3 = new Appointment(26, 1, 3, 3, false, true, new DateTime(2022, 1, 12, 8, 0, 0), 26, 3);

                context.Appointments.Add(appointment1);
                context.Appointments.Add(appointment2);
                context.Appointments.Add(appointment3);
                context.Patients.Add(patient1);
                context.Prescriptions.Add(prescription1);
                context.Prescriptions.Add(prescription2);
                context.Prescriptions.Add(prescription3);
                context.Doctors.Add(doctor1);
                context.Doctors.Add(doctor2);
                context.Doctors.Add(doctor3);


                context.SaveChanges();
            }
            return options;
        }
    }
}
