using Hospital.Mapper;
using Hospital.Shared_model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Hospital.Schedule.Model;

namespace Hospital.Shared_model.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        List<string> terms = new List<string> { "7:00", "7:30", "8:00", "8:30", "9:00", "9:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30",
                                                "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30" };
        private readonly HospitalDbContext dbContext;
        public AppointmentRepository(HospitalDbContext context) : base(context)
        {
            dbContext = context;
        }

        public Appointment CancelAppointment(int appointmentId)
        {
            Appointment appointment = GetById(appointmentId);
            appointment.isCancelled = true;
            dbContext.CanceledAppointments.Add(new CanceledAppointment(new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                                                                        appointment.PatientId, appointment.Id));
            Save();

            return appointment;
        }

        public List<Appointment> getAppointmentsByPatientId(int patinetId)
        {
            return dbContext.Appointments.Where(app => app.PatientId == patinetId).ToList();
        }

        public List<DateTime> GetAvailableTermsForDoctor(Doctor doctor, DateTime fromDate, DateTime toDate)
        {
            List<DateTime> allTerms = GenerateAllTerms(fromDate, toDate);
            List<DateTime> occupiedTerms = GetOccupiedTermsWithDoctorAsPriority(doctor, fromDate, toDate);
            List<DateTime> availableTerms = FindAvailableTermsWithDoctorAsPriority(doctor, allTerms, occupiedTerms);

            if (availableTerms.Count() != 0)
                return availableTerms;
            else
            {
                allTerms = GenerateAllTerms(fromDate.AddDays(-3), toDate.AddDays(3));
                occupiedTerms = GetOccupiedTermsWithDoctorAsPriority(doctor, fromDate.AddDays(-3), toDate.AddDays(3));
                return FindAvailableTermsWithDoctorAsPriority(doctor, allTerms, occupiedTerms);
            }
        }

        private List<DateTime> GetOccupiedTermsWithDoctorAsPriority(Doctor doctor, DateTime fromDate, DateTime toDate)
        {
            return dbContext.Appointments.Where(app => app.DoctorId == doctor.Id && app.Date.AddDays(1) > fromDate.Date && app.Date < toDate.Date.AddDays(1))
                                                                             .Select(a => a.Date).ToList();
        }

        private List<DateTime> FindAvailableTermsWithDoctorAsPriority(Doctor doctor, List<DateTime> allTerms, List<DateTime> occupiedTerms)
        {
            List<DateTime> availableTerms = new List<DateTime>();

            if (doctor.WorkShiftId == 1)
                availableTerms = allTerms.Where(t => !occupiedTerms.Contains(t) && t.Hour < 13).ToList();
            else if (doctor.WorkShiftId == 2)
                availableTerms = allTerms.Where(t => !occupiedTerms.Contains(t) && t.Hour >= 13).ToList();
            return availableTerms;
        }

        private List<DateTime> GetOccupiedTerms(Doctor doctor, DateTime fromDate, DateTime toDate)
        {
            return dbContext.Appointments.Where(app => app.DoctorId == doctor.Id && app.isCancelled == false && app.Date.AddDays(1) > fromDate.Date &&
                                                        app.Date < toDate.Date.AddDays(1)).Select(a => a.Date).ToList();
        }

        private List<DateTime> GenerateAllTerms(DateTime fromDate, DateTime toDate)
        {
            List<DateTime> allTerms = new List<DateTime>();
            DateTime day = fromDate.Date;
            while (day <= toDate.Date)
            {
                foreach (string term in terms)
                    allTerms.Add(new DateTime(day.Year, day.Month, day.Day, Convert.ToInt32(term.Split(":")[0]), Convert.ToInt32(term.Split(":")[1]), 0));

                day = day.AddDays(1);
            }

            return allTerms;
        }

        public TermsInDateRange GetAvailableTermsForDateRange(TermsInDateRange initialObjectWithoutTerms, List<Doctor> doctorsWithSpecialty)
        {
            Doctor initiallyPickedDoctor = initialObjectWithoutTerms.InitiallyPickedDoctor;
            DateTime beginningDateTime = initialObjectWithoutTerms.BeginningDateTime;
            DateTime endingDateTime = initialObjectWithoutTerms.EndingDateTime;

            List<DateTime> allTerms = GenerateAllTerms(beginningDateTime, endingDateTime);
            TermsInDateRangeForDoctor occupiedTerms = 
                GetOccupiedTermsWithDateRangeAsPriority(initiallyPickedDoctor, beginningDateTime, endingDateTime);
            TermsInDateRangeForDoctor availableTerms = 
                FindAvailableTermsWithDateRangeAsPriority(initiallyPickedDoctor, allTerms, occupiedTerms);

            TermsInDateRange availableTermsForDateRange = new TermsInDateRange(initialObjectWithoutTerms);
            if (availableTerms.Terms.Count > 0)
            {
                availableTermsForDateRange.TermsInDateRangeForDoctors.Add(availableTerms);
                return availableTermsForDateRange;
            }
            else
            {
                foreach (Doctor doctor in doctorsWithSpecialty)
                {
                    if (doctor.Id != initiallyPickedDoctor.Id)
                    {
                        occupiedTerms = GetOccupiedTermsWithDateRangeAsPriority(doctor, beginningDateTime, endingDateTime);
                        availableTerms = FindAvailableTermsWithDateRangeAsPriority(doctor, allTerms, occupiedTerms);

                        availableTermsForDateRange.TermsInDateRangeForDoctors.Add(availableTerms);
                    }
                }

                return availableTermsForDateRange;
            }
        }

        private TermsInDateRangeForDoctor GetOccupiedTermsWithDateRangeAsPriority(Doctor doctor, DateTime beginningDateTime, DateTime endingDateTime)
        {
            List<DateTime> occupiedTerms = dbContext.Appointments.Where(a => a.DoctorId == doctor.Id && 
                a.Date.AddDays(1) > beginningDateTime.Date && a.Date < endingDateTime.Date.AddDays(1))
                    .Select(a => a.Date).ToList();

            TermsInDateRangeForDoctor termsInDateRangeForDoctor = new TermsInDateRangeForDoctor(doctor, occupiedTerms);
            return termsInDateRangeForDoctor;
        }

        private TermsInDateRangeForDoctor FindAvailableTermsWithDateRangeAsPriority(Doctor doctor, List<DateTime> allTerms, TermsInDateRangeForDoctor occupiedTerms)
        {
            TermsInDateRangeForDoctor availableTerms = new TermsInDateRangeForDoctor(doctor, null);

            if (doctor.WorkShiftId == 1)
                availableTerms.Terms = allTerms.Where(t => !occupiedTerms.Terms.Contains(t) && t.Hour < 13).ToList();
            else if (doctor.WorkShiftId == 2)
                availableTerms.Terms = allTerms.Where(t => !occupiedTerms.Terms.Contains(t) && t.Hour >= 13).ToList();

            return availableTerms;
        }

        public void AddAppointment(Appointment app)
        {
            Add(app);
            Survey newSurvey = new Survey(app.Id);
            dbContext.Surveys.Add(newSurvey);
            Save();
            app.SurveyId = newSurvey.Id;
            Save();
        }

        public List<DateTime> GetAvailableTerms(Doctor doctor, DateTime date)
        {
            List<DateTime> allTerms = GenerateAllTerms(date, date);
            List<DateTime> occupiedTerms = GetOccupiedTerms(doctor, date, date);
            List<DateTime> availableTerms = FindAvailableTermsWithDoctorAsPriority(doctor, allTerms, occupiedTerms);

            return availableTerms;
        }
    }
}
