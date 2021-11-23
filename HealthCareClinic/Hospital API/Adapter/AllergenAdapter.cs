using Hospital.Mapper;
using Hospital.Medical_records.Service;
using Hospital.Schedule.Model;
using Hospital.Schedule.Service;
using Hospital.Shared_model.Model;
using Hospital.Shared_model.Repository;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class AllergenAdapter
    {
        public static List<AllergenDTO> AllergenListToDtoList(List<Allergen> allergens)
        {
            List<AllergenDTO> dtoList = new List<AllergenDTO>();

            foreach (Allergen a in allergens)
            {
                AllergenDTO dto = new AllergenDTO();
                dto.Id = a.Id;
                dto.Name = a.Name;
                dtoList.Add(dto);
            }
            

            return dtoList;
        }

        //public static List<Allergen> AllergenDTOToAllergen(List<AllergenDTO> allergenDTOs)
        //{
        //    List<Allergen> allergens = new List<Allergen>();

        //    foreach (AllergenDTO a in allergenDTOs)
        //    {
        //        Allergen al = new Allergen();
        //        al.Id = a.Id;
        //        al.Name = a.Name;
        //        allergens.Add(al);
        //    }

        //    return allergens;
        //}

        public static Allergen AllergenDTOToAllergen(AllergenDTO dto)
        {
            Allergen al = new Allergen();
            al.Id = dto.Id;
            al.Name = dto.Name;

            return al;         
        }

        public static AllergenDTO AllergenToAllergenDTO(Allergen a)
        {
            AllergenDTO dto = new AllergenDTO();
            dto.Id = a.Id;
            dto.Name = a.Name;

            return dto;
        }

        public static ICollection<AllergenForPatient> AllergenDTOListToAllergenForPatientList(ICollection<AllergenDTO> allergens, int patientId)
        {
            ICollection<AllergenForPatient> AllergensForPatient = new List<AllergenForPatient>();

            if (allergens != null)
                foreach (AllergenDTO allergenDTO in allergens)
                {
                    AllergenForPatient al = new AllergenForPatient(allergenDTO.Id, patientId, allergenDTO.Name);
                    AllergensForPatient.Add(al);
                }

            return AllergensForPatient;
        }

        public static ICollection<AllergenDTO> AllergenForPatientListToAllergenDTOList(ICollection<AllergenForPatient> AllergensForPatient)
        {
            ICollection<AllergenDTO> AllergensDTO = new List<AllergenDTO>();

            if (AllergensForPatient != null)
                foreach (AllergenForPatient afp in AllergensForPatient)
                {
                    AllergenDTO allergenDTO = new AllergenDTO();
                    allergenDTO.Name = afp.Name;
                    allergenDTO.Id = afp.AllergenId;
                    AllergensDTO.Add(allergenDTO);
                }

            return AllergensDTO;
        }
    }
}
