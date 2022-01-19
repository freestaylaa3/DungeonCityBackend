using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Item:IEntity
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int ItemTypeId { get; set; }
        public int ItemPrice { get; set; }
        public int ItemRarity { get; set; }
        public float BasePhysical { get; set; }
        public float BaseMagical { get; set; }
        public ItemType ItemType { get; set; }
    }
}
