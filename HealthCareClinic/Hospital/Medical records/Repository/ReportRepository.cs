using Hospital.Mapper;
using Hospital.Medical_records.Model;
using Hospital.Medical_records.Repository.Interface;
using Hospital.Shared_model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Medical_records.Repository
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        private readonly HospitalDbContext _dbContext;

        public ReportRepository(HospitalDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
