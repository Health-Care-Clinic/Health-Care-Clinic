using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Pharmacy.Model
{
    public class MedicationConsumption
    {
        public MedicationConsumption()
        {
        }

        public MedicationConsumption(int id, string name, int amount, DateTime date)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Date = date;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
