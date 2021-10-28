using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Storages
{
    public class PatientAppointmentEvaluationStorage
    {
        private string fileLocation;

        public PatientAppointmentEvaluationStorage()
        {
            this.fileLocation = "../../../FileStorage/appointmentEvaluations.json";
        }

        public List<PatientAppointmentEvaluation> GetAll()
        {
            /*String text = File.ReadAllText(this.fileLocation);
            List<PatientAppointmentEvaluation> allAppointmentEvaluations = JsonConvert.DeserializeObject<List<PatientAppointmentEvaluation>>(text);
            return allAppointmentEvaluations;*/
            return null;
        }

        public void SaveAppointments(List<PatientAppointmentEvaluation> allAppointmentEvaluations)
        {
            /*var file = JsonConvert.SerializeObject(allAppointmentEvaluations, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            using (StreamWriter writer = new StreamWriter(this.fileLocation))
            {
                writer.Write(file);
            }*/
        }
    }
}
