using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Pharmacy_API.DTO
{
    public class MessageDTO
    {
        public String MessageText { get; set; }
        public MessageDTO() { }
        public MessageDTO(String messageText)
        {
            this.MessageText = messageText;
        }
    }
}
