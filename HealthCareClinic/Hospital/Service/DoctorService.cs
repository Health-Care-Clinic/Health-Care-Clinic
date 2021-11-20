using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicCore.Service;
using Hospital.Mapper;
using Hospital.Repository.Interface;
using Model;

namespace Hospital.Service
{
    public class DoctorService : IService<Doctor>
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }
        public void Add(Doctor entity)
        {
            doctorRepository.Add(entity);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return doctorRepository.GetAll();
        }

        public Doctor GetOneById(int id)
        {
            return doctorRepository.GetById(id);
        }

        public void Remove(Doctor entity)
        {
            doctorRepository.Remove(entity);
        }

        public List<Doctor> GetAllGeneralMedicineDoctors()
        {
            List<Doctor> generalMedicineDoctors = new List<Doctor>();

            foreach (Doctor doctor in doctorRepository.GetAll())
            {
                if (doctor.Specialty.Name.Equals("General medicine"))
                    generalMedicineDoctors.Add(doctor);
            }

            return generalMedicineDoctors;
        }


        public List<Doctor> GetNonOverOcuipedDoctors()
        {
            List<Doctor> noneOverOcupiedDoctors = new List<Doctor>();
            int min = GetAllGeneralMedicineDoctors()[0].Patient.Count;

            foreach (Doctor doctor in GetAllGeneralMedicineDoctors())
                if (doctor.Patient.Count < min)
                    min = doctor.Patient.Count;
            foreach (Doctor doctor in GetAllGeneralMedicineDoctors())
                if (doctor.Patient.Count <= min + 2)
                    noneOverOcupiedDoctors.Add(doctor);


            return noneOverOcupiedDoctors;
        }

    }
}
