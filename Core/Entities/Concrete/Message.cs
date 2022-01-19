using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageTime { get; set; }
    }
}
