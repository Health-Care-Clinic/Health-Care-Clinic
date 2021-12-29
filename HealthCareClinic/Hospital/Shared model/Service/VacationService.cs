using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public class VacationService : IVacationService
    {
        private readonly IVacationRepository _vacationRepository;

        public VacationService(IVacationRepository vacationRepository)
        {
            _vacationRepository = vacationRepository;
        }

        public IEnumerable<Vacation> GetAll()
        {
            return _vacationRepository.GetAll();
        }

        public Vacation GetOneById(int id)
        {
            return _vacationRepository.GetById(id);
        }

        public void Add(Vacation entity)
        {
            _vacationRepository.Add(entity);
        }

        public void Change(Vacation entity)
        {
            _vacationRepository.Change(entity);
        }

        public void Remove(Vacation entity)
        {
            _vacationRepository.Remove(entity);
        }

        public void RemoveById(int id)
        {
            _vacationRepository.RemoveById(id);
        }

        public List<Vacation> GetVacationsByDoctorId(int doctorId)
        {
            return _vacationRepository.GetVacationsByDoctorId(doctorId);
        }

        public List<Vacation> GetPastVacationsByDoctorId(int doctorId)
        {
            List<Vacation> allVacations = _vacationRepository.GetVacationsByDoctorId(doctorId);
            List<Vacation> pastVacations = new List<Vacation>();

            foreach (Vacation v in allVacations)
            {
                if (v.EndTime.CompareTo(DateTime.Now) < 0)
                {
                    pastVacations.Add(v);
                }
            }

            return pastVacations;
        }

        public List<Vacation> GetCurrentVacationsByDoctorId(int doctorId)
        {
            List<Vacation> allVacations = _vacationRepository.GetVacationsByDoctorId(doctorId);
            List<Vacation> currentVacations = new List<Vacation>();

            foreach (Vacation v in allVacations)
            {
                if (v.StartTime.CompareTo(DateTime.Now) < 0 && v.EndTime.CompareTo(DateTime.Now) > 0)
                {
                    currentVacations.Add(v);
                }
            }

            return currentVacations;
        }

        public List<Vacation> GetFutureVacationsByDoctorId(int doctorId)
        {
            List<Vacation> allVacations = _vacationRepository.GetVacationsByDoctorId(doctorId);
            List<Vacation> futureVacations = new List<Vacation>();

            foreach (Vacation v in allVacations)
            {
                if (v.StartTime.CompareTo(DateTime.Now) > 0)
                {
                    futureVacations.Add(v);
                }
            }

            return futureVacations;
        }
    }
}
