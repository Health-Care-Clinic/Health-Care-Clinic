using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ClinicCore.Storages
{
    class SpecializationFileStorage
    {
        private String FileLocation;

        public SpecializationFileStorage()
        {
            this.FileLocation = "../../../FileStorage/specializations.json";
        }

        public List<Specialty> GetAll()
        {

            //List<Specialty> allSpecialties = new List<Specialty>();
            //allSpecialties.Add(new Specialty(""));
            //allSpecialties.Add(new Specialty("Dermatolog"));
            //allSpecialties.Add(new Specialty("Stomatolog"));
            //allSpecialties.Add(new Specialty("Infektolog"));

            /*String text = File.ReadAllText(this.FileLocation);
            List<Specialty> allSpecialties = JsonConvert.DeserializeObject<List<Specialty>>(text);
            return allSpecialties;*/
            return null;

        }



        public void SaveSpecialties(List<Specialty> allSpecialties)
        {
            /*var file = JsonConvert.SerializeObject(allSpecialties, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            using (StreamWriter writer = new StreamWriter(this.FileLocation))
            {
                writer.Write(file);
            }*/
        }
    }
    
}
