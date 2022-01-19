using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfItemDal : EfEntityRepositoryBase<Item, DungeonCityContext>, IItemDal
    {
        public List<Item> GetItems()
        {
            using var context = new DungeonCityContext();
            var result = from item in context.Item
                         join type in context.ItemType
                         on item.ItemTypeId equals type.ItemTypeId
                         select new Item
                         {
                             ItemId = item.ItemId,
                             ItemTypeId = item.ItemTypeId,
                             ItemDescription = item.ItemDescription,
                             ItemRarity = item.ItemRarity,
                             ItemPrice = item.ItemPrice,
                             ItemName = item.ItemName,
                             BaseMagical = item.BaseMagical,
                             BasePhysical = item.BasePhysical,
                             ItemType = type
                         };
            return result.ToList();
        }

        public ItemType GetType(int itemId)
        {
            using var context = new DungeonCityContext();
            var type = context.ItemType.Single(t => t.ItemTypeId == itemId);
            return type;
        }
    }
}
