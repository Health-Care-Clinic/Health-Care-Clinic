using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Storages
{
    public class TransferStorage
    {
        private string fileLocation;

        public TransferStorage()
        {
            this.fileLocation = "../../../FileStorage/transfer.json";
        }

        public List<Transfer> GetAll()
        {
            /*String text = File.ReadAllText(this.fileLocation);
            List<Transfer> allTransfers = JsonConvert.DeserializeObject<List<Transfer>>(text);
            return allTransfers;*/
            return null;
        }

       

        public void Save(List<Transfer> allTransfers)
        {
            /*var file = JsonConvert.SerializeObject(allTransfers, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            using (StreamWriter writer = new StreamWriter(this.fileLocation))
            {
                writer.Write(file);
            }*/
        }
    }
}
