using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public byte[] UserPasswordSalt { get; set; }
        public byte[] UserPasswordHash { get; set; }
        public int UserExp { get; set; }
        public int UserLevel { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastLogin { get; set; }
        public bool Status { get; set; }
        public int Money { get; set; }
        public int UserHealth { get; set; }
    }
}
