using System;

namespace ClinicCore.DTOs
{
    public class MedicineComponentDTO
    {
        public String Component { get; set; }

        public MedicineComponentDTO(string component)
        {
            this.Component = component;
        }
    }
}
