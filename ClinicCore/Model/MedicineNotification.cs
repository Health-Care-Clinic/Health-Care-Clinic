using System;
using System.Collections.Generic;

namespace Model
{
    public class MedicineNotification
    {
        public List<int> SenderId { get; set; } = new List<int>();
        public String Title { get; set; }
        public Medicine Medicine { get; set; }
        public List<int> RecieverIds { get; set; }
        public String Note { get; set; }

        public DateTime DateSent { get; set; }

        public int ApprovalCounter { get; set; }

        public MedicineNotification(string title, Medicine medicine, List<int> recieverIds)
        {
            Title = title;
            Medicine = medicine;
            RecieverIds = recieverIds;
        }
    }
}
