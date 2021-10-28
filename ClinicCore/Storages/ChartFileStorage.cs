using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Storages
{
    public class ChartFileStorage
    {
        private string fileLocation;

        public ChartFileStorage()
        {
            this.fileLocation = "../../../FileStorage/patientCharts.json";
        }

        public List<MedicalHistory> GetAll()
        {
            /*String text = File.ReadAllText(this.fileLocation);
            List<MedicalHistory> allCharts = JsonConvert.DeserializeObject<List<MedicalHistory>>(text);
            return allCharts;*/
            return null;
        }

        public void SaveCharts(List<MedicalHistory> allCharts)
        {
            /*var file = JsonConvert.SerializeObject(allCharts, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            using (StreamWriter writer = new StreamWriter(this.fileLocation))
            {
                writer.Write(file);
            }*/
        }
    }
}
