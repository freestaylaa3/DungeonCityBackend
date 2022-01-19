using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IItemService
    {
        ItemType GetType(int itemId);
        IDataResult<List<Item>> GetItems();
        IDataResult<Item> GetById(int itemId);
        IResult Add(Item item);
        IResult Delete(Item item);
        IResult Update(Item item);
    }
}
