using Model;
using System.Collections.Generic;

namespace ClinicCore.Storages
{
    public class MedicineFileStorage
    {
        private string fileLocation;

        public MedicineFileStorage()
        {
            this.fileLocation = "../../../FileStorage/medicines.json";
        }

        public List<Medicine> GetAll()
        {
            /*String text = File.ReadAllText(this.fileLocation);
            List<Medicine> medicines = JsonConvert.DeserializeObject<List<Medicine>>(text);
            return medicines;*/
            return null;
        }

        public void Save(List<Medicine> medicines)
        {
            /*var file = JsonConvert.SerializeObject(medicines, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            using (StreamWriter writer = new StreamWriter(this.fileLocation))
            {
                writer.Write(file);
            }*/
        }
    }
}
