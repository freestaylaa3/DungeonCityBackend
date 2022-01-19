using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ItemDto:IDto
    {
        public ItemDto()
        {
            Attributes = new List<Core.Entities.Concrete.Attribute>() { };
        }
        public int ItemId { get; set; }
        public int UserItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int ItemPrice { get; set; }
        public int ItemRarity { get; set; }
        public float BasePhysical { get; set; }
        public float BaseMagical { get; set; }
        public bool isEquipped { get; set; }
        public List<Core.Entities.Concrete.Attribute> Attributes { get; set; }
        public ItemType ItemType { get; set; }

    }
}
