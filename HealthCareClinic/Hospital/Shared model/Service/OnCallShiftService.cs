using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Service
{
    public class OnCallShiftService : IOnCallShiftService
    {
        private readonly IOnCallShiftRepository _onCallShiftRepository;

        public OnCallShiftService(IOnCallShiftRepository onCallShiftRepository)
        {
            _onCallShiftRepository = onCallShiftRepository;
        }
        public void Add(OnCallShift entity)
        {
            _onCallShiftRepository.Add(entity);
        }

        public IEnumerable<OnCallShift> GetAll()
        {
            return _onCallShiftRepository.GetAll();
        }

        public List<OnCallShift> GetOnCallShiftByDoctorId(int doctorId)
        {
            return _onCallShiftRepository.GetOnCallShiftByDoctorId(doctorId);
        }

        public OnCallShift GetOneById(int id)
        {
            return _onCallShiftRepository.GetById(id);
        }

        public void Remove(OnCallShift entity)
        {
            _onCallShiftRepository.Remove(entity);
        }
    }
}
