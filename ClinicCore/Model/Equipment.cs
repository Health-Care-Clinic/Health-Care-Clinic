using Enums;
using System;

namespace Model
{
    public class Equipment
    {
        public EquiptType EquipType { get; set; }
        public int EquiptId { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }
        public String ProducerName { get; set; }

     
        public int EquiptTypeIndex
        {
            set { }
            get { return (int)EquipType; }
        }

        public Equipment(EquiptType equipType, int equiptId, string name, int quantity)
        {
            this.EquipType = equipType;
            this.EquiptId = equiptId;
            this.Name = name;
            this.Quantity = quantity;
          
        }

        public Equipment(EquiptType equipType, string name, int quantity, string producerName)
        {
            EquipType = equipType;
            Name = name;
            Quantity = quantity;
            ProducerName = producerName;
        }

      

        public Equipment()
        {

        }


    }
}