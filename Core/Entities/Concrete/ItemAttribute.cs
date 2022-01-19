using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class ItemAttribute:IEntity
    {
        public int ItemAttributeId { get; set; }
        public int UserItemId { get; set; }
        public int AttributeId { get; set; }
    }
}
