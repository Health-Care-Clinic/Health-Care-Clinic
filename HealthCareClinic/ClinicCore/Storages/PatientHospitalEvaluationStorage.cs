using ClinicCore.Model;
using System.Collections.Generic;

namespace ClinicCore.Storages
{
    public class PatientHospitalEvaluationStorage
    {
        private string fileLocation;

        public PatientHospitalEvaluationStorage()
        {
            this.fileLocation = "../../../FileStorage/hospitalEvaluations.json";
        }

        public List<PatientHospitalEvaluation> GetAll()
        {
            /*String text = File.ReadAllText(this.fileLocation);
            List<PatientHospitalEvaluation> allHospitalEvaluations = JsonConvert.DeserializeObject<List<PatientHospitalEvaluation>>(text);
            return allHospitalEvaluations;*/
            return null;
        }

        public void SaveAppointments(List<PatientHospitalEvaluation> allHospitalEvaluations)
        {
            /*var file = JsonConvert.SerializeObject(allHospitalEvaluations, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            using (StreamWriter writer = new StreamWriter(this.fileLocation))
            {
                writer.Write(file);
            }*/
        }
    }
}
