using Hospital.Medical_records.Service;
using Hospital.Schedule.Model;
using Hospital.Schedule.Service;
using Hospital.Shared_model.Model;
using Hospital_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_API.Adapter
{
    public class AllergenAdapter
    {
        public static List<AllergenDTO> AllergenToDto(List<Allergen> allergens)
        {
            List<AllergenDTO> dtoList = new List<AllergenDTO>();

            foreach (Allergen a in allergens)
            {
                AllergenDTO dto = new AllergenDTO();
                dto.Id = a.Id;
                dto.Name = a.Name;
                dto.PatientId = a.PatientId;
                dtoList.Add(dto);
            }
            

            return dtoList;
        }

        public static List<Allergen> AllergenDTOToAllergen(List<AllergenDTO> allergenDTOs)
        {
            List<Allergen> allergens = new List<Allergen>();

            foreach (AllergenDTO a in allergenDTOs)
            {
                Allergen al = new Allergen();
                al.Id = a.Id;
                al.Name = a.Name;
                al.PatientId = a.PatientId;
                allergens.Add(al);
            }

            return allergens;
        }

    }
}
