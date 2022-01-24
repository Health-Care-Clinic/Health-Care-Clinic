using Pharmacy.Advertisements.Model;
using System;
using System.Collections.Generic;

namespace Pharmacy.Prescriptions.Model
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public string Usage { get; set; }
        public int Weight { get; set; }
        public String SideEffects { get; set; }
        public String Reactions { get; set; }
        public String CompatibileMedicine { get; set; }
        public double Price { get; set; }
        public virtual ICollection<AdvertisementMedicine> AdvertisementMedicines { get; set; }

        public Medicine(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public Medicine(int id, string name, int quantity, string manufacturer, string usage, int weight, String sideEffects, String reactions, String compatibileMedicine) : this(id, name, quantity)
        {
            Manufacturer = manufacturer;
            Usage = usage;
            Weight = weight;
            SideEffects = sideEffects;
            Reactions = reactions;
            CompatibileMedicine = compatibileMedicine;
        }

        public Medicine(int id, string name, int quantity, string manufacturer, string usage, int weight, String sideEffects, String reactions, String compatibileMedicine, double price) : this(id, name, quantity)
        {
            Manufacturer = manufacturer;
            Usage = usage;
            Weight = weight;
            SideEffects = sideEffects;
            Reactions = reactions;
            CompatibileMedicine = compatibileMedicine;
            Price = price;
        }



        public Medicine() {
            
        }


        public Boolean CheckQuantity(int quantiity)
        {
            bool result = false;
            if(quantiity <= Quantity)
            {
                result = true;
            }
            return result;
        }

    }
}
