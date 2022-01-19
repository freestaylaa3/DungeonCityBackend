using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ItemManager : IItemService
    {
        private IItemDal _itemDal;

        public ItemManager(IItemDal itemDal)
        {
            _itemDal = itemDal;
        }

        public IResult Add(Item item)
        {
            _itemDal.Add(item);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Item item)
        {
            _itemDal.Delete(item);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Item> GetById(int itemId)
        {
            return new SuccessDataResult<Item>(_itemDal.Get(i => i.ItemId == itemId));
        }

        public IDataResult<List<Item>> GetItems()
        {

            return new SuccessDataResult<List<Item>>(_itemDal.GetItems().ToList());
        }

        public ItemType GetType(int itemId)
        {
            var type = _itemDal.GetType(itemId);
            return type;
        }

        public IResult Update(Item item)
        {
            _itemDal.Update(item);
            return new SuccessResult(Messages.ProductUpdated);
        }

    }
}
