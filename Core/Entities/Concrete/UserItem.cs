using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserItem:IEntity
    {
        public int UserItemId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public float PhysicalBonus { get; set; }
        public float MagicalBonus { get; set; }
        public bool IsEquipped { get; set; }
        public int UpgradeCount { get; set; }
    }
}
