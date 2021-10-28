using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Storages
{
    public class AdvancedRenovationStorage
    {

        private string fileLocation;


        public AdvancedRenovationStorage()
        {
            this.fileLocation = "../../../FileStorage/advancedrenovations.json";
        }

        public List<AdvancedRenovation> GetAll()
        {
            /*String text = File.ReadAllText(this.fileLocation);
            List<AdvancedRenovation> transfers = JsonConvert.DeserializeObject<List<AdvancedRenovation>>(text);
         
            return transfers;*/
            return null;
        }


        public void Save(List<AdvancedRenovation> allTransfers)
        {
           
            /*var file = JsonConvert.SerializeObject(allTransfers, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            using (StreamWriter writer = new StreamWriter(this.fileLocation))
            {
                writer.Write(file);
            }*/
        }
  
    }
   
}
