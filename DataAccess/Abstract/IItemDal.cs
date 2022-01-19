using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IItemDal: IEntityRepository<Item>
    {
        ItemType GetType(int itemId);
        List<Item> GetItems();
    }
}
