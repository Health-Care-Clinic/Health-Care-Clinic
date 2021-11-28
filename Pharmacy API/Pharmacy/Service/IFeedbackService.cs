using Pharmacy.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Service
{
    public interface IFeedbackService : IService<Feedback>
    {
        void SaveChanges();
    }
}
