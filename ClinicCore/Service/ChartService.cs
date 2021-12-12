using ClinicCore.DTOs;
using Model;
using Storages;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ChartService
    {
        private ChartFileStorage cfs = new ChartFileStorage();
        public List<MedicalHistory> AllCharts { get; set; }

        private static ChartService instance = null;
        public static ChartService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChartService();
                }
                return instance;
            }
        }

        private ChartService()
        {
            AllCharts = cfs.GetAll();
        }

        public List<Therapy> GetTherapiesByPatientId(int id)
        {
            MedicalHistory medicalHistory = GetChartById(id);
            return medicalHistory.Therapies;
        }

        public List<Test> GetTestsByPatientId(int id)
        {
            MedicalHistory medicalHistory = GetChartById(id);
            return medicalHistory.Test;
        }

        public MedicalHistory GetChartById(int id)
        {
            foreach(MedicalHistory medicalHistory in AllCharts)
            {
                if (medicalHistory.Id.Equals(id))
                {
                    return medicalHistory;
                }
            }
            return null;
        }

        public List<Prescription> GetPrescriptionsByPatientId(int id)
        {
            MedicalHistory medicalHistory = GetChartById(id);
            return medicalHistory.Prescription;
        }

        public List<Prescription> GetPrescriptionsForReport(int id, DateTime reportId)
        {
            List<Prescription> allPrescriptions = GetPrescriptionsByPatientId(id);
            List<Prescription> reportPrescriptions = new List<Prescription>();
            foreach (Prescription prescription in allPrescriptions)
            {
                if (prescription.DatePrescribed.Equals(reportId))
                {
                    reportPrescriptions.Add(prescription);
                }
            }
            return reportPrescriptions;
        }

        public List<Test> GetTestsForReport(int id, DateTime reportId)
        {
            List<Test> allTests = GetTestsByPatientId(id);
            List<Test> reportTests = new List<Test>();
            foreach (Test test in allTests)
            {
                if (test.SampleDate.Equals(reportId))
                {
                    reportTests.Add(test);
                }
            }
            return reportTests;
        }

        public Hospitalization GetActivHospitalization(int id)
        {
            Hospitalization ret = null;
            List<Hospitalization> allHospitalizations = GetHospitalizationsByPatientId(id);
            foreach (Hospitalization hospitalization in allHospitalizations)
            {
                if (hospitalization.IsReleased == false)
                {
                    ret = hospitalization;
                }
            }
            return ret;
        }

        public void ReleasePatient(int id)
        {
            MedicalHistory medicalHistory = GetChartById(id);
            for (int i = 0; i < medicalHistory.Hospitalization.Count; i++)
            {
                if (medicalHistory.Hospitalization[i].IsReleased == false)
                {
                    medicalHistory.Hospitalization[i].IsReleased = true;
                    cfs.SaveCharts(AllCharts);
                    return;
                }
            }
        }

        public void AddPrescriptions(List<Prescription> prescriptions, int id)
        {
            MedicalHistory medicalHistory = GetChartById(id);
            medicalHistory.Prescription.AddRange(prescriptions);
            cfs.SaveCharts(AllCharts);
        }

        public void AddReport(Report newReport, int id)
        {
            MedicalHistory medicalHistory = GetChartById(id);
            medicalHistory.Reports.Add(newReport);
            cfs.SaveCharts(AllCharts);
        }

        public void AddHospitalization(Hospitalization newHospitalization, int id)
        {
            MedicalHistory medicalHistory = GetChartById(id);
            medicalHistory.Hospitalization.Add(newHospitalization);
            cfs.SaveCharts(AllCharts);
        }

        public void AddTherapy(Therapy newTherapy, int id)
        {
            MedicalHistory medicalHistory = GetChartById(id);
            medicalHistory.Therapies.Add(newTherapy);
            cfs.SaveCharts(AllCharts);
        }

        public void AddTest(Test newTest, int id)
        {
            MedicalHistory medicalHistory = GetChartById(id);
            medicalHistory.Test.Add(newTest);
            cfs.SaveCharts(AllCharts);
        }

        public void UpdateReport(int id, Report report)
        {
            MedicalHistory medicalHistory = GetChartById(id);
            for (int i = 0; i < medicalHistory.Reports.Count; i++)
            {
                if (medicalHistory.Reports[i].ReportId.Equals(report.ReportId))
                {
                    medicalHistory.Reports.RemoveAt(i);
                    medicalHistory.Reports.Insert(i, report);
                    cfs.SaveCharts(AllCharts);
                    return;
                }
            }
        }

        public List<Report> GetReportsByPatientId(int id)
        {
            MedicalHistory medicalHistory = GetChartById(id);
            return medicalHistory.Reports;
        }

        public List<Hospitalization> GetHospitalizationsByPatientId(int id)
        {
            MedicalHistory medicalHistory = GetChartById(id);
            return medicalHistory.Hospitalization;
        }

        public void SaveChart(MedicalHistory medicalHistory)
        {
            AllCharts.Add(medicalHistory);
            cfs.SaveCharts(AllCharts);
        }

        public void DeleteChart(int idChart)
        {
            foreach(MedicalHistory medicalHistory in AllCharts)
            {
                if (medicalHistory.Id.Equals(idChart))
                {
                    AllCharts.Remove(medicalHistory);
                    cfs.SaveCharts(AllCharts);
                    return;
                }
            }
            return;
        }

        public int GetNumberOfTherapiesByMonth(int patientId, string month)
        {
            int numberOfTherapiesForMonth = 0;
            switch (month)
            {
                case "Jan":
                    numberOfTherapiesForMonth = CheckMonth(patientId, 1);
                    break;
                case "Feb":
                    numberOfTherapiesForMonth = CheckMonth(patientId, 2);
                    break;
                case "Mar":
                    numberOfTherapiesForMonth = CheckMonth(patientId, 3);
                    break;
                case "Apr":
                    numberOfTherapiesForMonth = CheckMonth(patientId, 4);
                    break;
                case "May":
                    numberOfTherapiesForMonth = CheckMonth(patientId, 5);
                    break;
                case "June":
                    numberOfTherapiesForMonth = CheckMonth(patientId, 6);
                    break;
                case "July":
                    numberOfTherapiesForMonth = CheckMonth(patientId, 7);
                    break;
                case "Aug":
                    numberOfTherapiesForMonth = CheckMonth(patientId, 8);
                    break;
                case "Sep":
                    numberOfTherapiesForMonth = CheckMonth(patientId, 9);
                    break;
                case "Oct":
                    numberOfTherapiesForMonth = CheckMonth(patientId, 10);
                    break;
                case "Nov":
                    numberOfTherapiesForMonth = CheckMonth(patientId, 11);
                    break;
                case "Dec":
                    numberOfTherapiesForMonth = CheckMonth(patientId, 12);
                    break;
            }
            return numberOfTherapiesForMonth;
        }

        private int CheckMonth(int patientId, int month)
        {
            int counter = 0;
            foreach (Therapy therapy in GetTherapiesByPatientId(patientId))
            {
                if (therapy.TherapyStart.Month == month)
                {
                    counter++;
                }
            }
            return counter;
        }

        public List<Therapy> FindTherapiesInTimeRange(TherapyReportDTO therapyReportDTO)
        {
            List<Therapy> patientTherapies = GetTherapiesByPatientId(therapyReportDTO.PatientId);
            List<Therapy> therapiesInTimeRange = new List<Therapy>();
            foreach (Therapy therapy in patientTherapies)
            {
                if(therapy.TherapyStart.Date >= therapyReportDTO.ReportStart.Date && therapy.TherapyStart.Date <= therapyReportDTO.ReportEnd.Date)
                {
                    therapiesInTimeRange.Add(therapy);
                }
            }
            return therapiesInTimeRange;
        }
    }
}
