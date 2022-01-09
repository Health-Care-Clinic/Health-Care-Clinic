
namespace ClinicCore.DTOs
{
    public class UsedEquipmentDTO
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public UsedEquipmentDTO(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }
    }
}
