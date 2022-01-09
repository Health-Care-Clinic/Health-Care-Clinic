using System;

namespace Model
{
    public class MedicineComponent
    {
        public String Component { get; set; }

        public MedicineComponent(string component)
        {
            this.Component = component;
        }
    }
}
