using ClinicCore.Storages;
using Integration.Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Interface.Repository
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        Feedback GetBySenderId(int id);
        List<Feedback> GetAllFeedbacksBySenderId(int id);
    }
}
