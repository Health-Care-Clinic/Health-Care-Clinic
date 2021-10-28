using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Storages
{
    public class ClassicAppointmentStorage
    {

        private string fileLocation;

        public ClassicAppointmentStorage()
        {
            this.fileLocation = "../../../FileStorage/classicAppointment.json";
        }

        public List<Appointment> GetAll()
        {
            /*String text = File.ReadAllText(this.fileLocation);
            List<Appointment> allAppointments = JsonConvert.DeserializeObject<List<Appointment>>(text);
          
            return allAppointments;*/
            return null;
        }

       

        public void SaveAppointment(List<Appointment> allAppointments)
        {
            /*var file = JsonConvert.SerializeObject(allAppointments, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            using (StreamWriter writer = new StreamWriter(this.fileLocation))
            {
                writer.Write(file);
            }*/
        }


    }
}
