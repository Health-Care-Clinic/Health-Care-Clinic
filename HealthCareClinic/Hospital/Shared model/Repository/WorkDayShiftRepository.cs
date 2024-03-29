﻿using Hospital.Mapper;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Shared_model.Repository
{
    public class WorkDayShiftRepository : Repository<WorkDayShift>, IWorkDayShiftRepository
    {
        public WorkDayShiftRepository(HospitalDbContext context) : base(context)
        {
        }

        public HospitalDbContext HospitalDbContext
        {
            get { return Context; }
        }

        public void RemoveById(int id)
        {
            Context.Set<WorkDayShift>().Remove(Context.Set<WorkDayShift>().Find(id));
            Context.SaveChanges();
        }

        public void Edit(WorkDayShift workDayShift)
        {
            Context.Set<WorkDayShift>().Find(workDayShift.Id).Name = workDayShift.Name;
            Context.Set<WorkDayShift>().Find(workDayShift.Id).WorkHour = new WorkHour(workDayShift.WorkHour.StartTime, workDayShift.WorkHour.EndTime);
            Context.SaveChanges();
        }
    }
}
