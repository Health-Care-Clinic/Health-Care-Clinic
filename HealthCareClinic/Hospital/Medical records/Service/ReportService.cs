using Hospital.Medical_records.Model;
using Hospital.Medical_records.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Medical_records.Service
{
    class ReportService : IReportService
    {
        private readonly IReportRepository reportRepository;

        public ReportService(IReportRepository _reportRepository)
        {
            reportRepository = _reportRepository;
        }
        public void Add(Report entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> GetAll()
        {
            throw new NotImplementedException();
        }

        public Report GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Report entity)
        {
            throw new NotImplementedException();
        }
    }
}
