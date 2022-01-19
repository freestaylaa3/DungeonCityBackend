using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class ItemType:IEntity
    {
        public int ItemTypeId { get; set; }
        public string ItemTypeName { get; set; }
        public bool IsEquipable { get; set; }
    }
}
