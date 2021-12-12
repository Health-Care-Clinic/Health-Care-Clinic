using ClinicCore.Storages;
using Model;
using System.Collections.Generic;

namespace Service
{
    public class SpecializationService
    {
        private SpecializationFileStorage sfs = new SpecializationFileStorage();
        public List<Specialty> AllSpecialties { get; set; }

        private static SpecializationService instance = null;
        public static SpecializationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SpecializationService();
                }
                return instance;
            }
        }

        private SpecializationService()
        {
            AllSpecialties = sfs.GetAll();
        }

        public List<Specialty> GetAll()
        {
            return AllSpecialties;
        }

        public List<string> GetAllNames()
        {
            List<string> specialties = new List<string>();
            foreach (Specialty specialty in AllSpecialties)
                specialties.Add(specialty.Name);
            return specialties;
        }

        public Specialty GetSpecialtyByName(string specialtyName)
        {
            Specialty spec = null;
            foreach (Specialty specialty in AllSpecialties)
            {
                if (specialty.Name.Equals(specialtyName))
                    spec = specialty;
            }
            return spec;
        }
    }
}
