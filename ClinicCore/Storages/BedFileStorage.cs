using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Storages
{
    class BedFileStorage
    {
        private string fileLocation;

        public BedFileStorage()
        {
            this.fileLocation = "../../../FileStorage/beds.json";
        }

        public List<Bed> GetAll()
        {
            /*String text = File.ReadAllText(this.fileLocation);
            List<Bed> allBeds = JsonConvert.DeserializeObject<List<Bed>>(text);
            return allBeds;*/
            return null;
        }

        public void SaveBeds(List<Bed> allBeds)
        {
            var file = JsonConvert.SerializeObject(allBeds, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            using (StreamWriter writer = new StreamWriter(this.fileLocation))
            {
                writer.Write(file);
            }
        }
    }
}
