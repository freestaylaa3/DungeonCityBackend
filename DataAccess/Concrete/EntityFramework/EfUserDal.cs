
using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal: EfEntityRepositoryBase<User, DungeonCityContext>, IUserDal
    {
        private IUserItemDal _userItemDal;
        public EfUserDal(IUserItemDal userItemDal)
        {
            _userItemDal = userItemDal;
        }

        public void AddItem(int itemId, int userId)
        {
            using var context = new DungeonCityContext();
            var uItem = new UserItem()
            {
                ItemId = itemId,
                UserId = userId,
                UserItemId = 0,
                UpgradeCount = 0,
                IsEquipped = false,
                MagicalBonus = 0,
                PhysicalBonus = 0,
            };
            _userItemDal.Add(uItem);
        }

        public void DeleteItem(int userItemId)
        {
            using var context = new DungeonCityContext();
            var userItem = context.UserItem.Single(u => u.UserItemId == userItemId);
            _userItemDal.Delete(userItem);
        }

        public void UpdateItem(UserItem userItem)
        {
            _userItemDal.Update(userItem);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using var context = new DungeonCityContext();
            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.UserId
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }

        public List<ItemDto> GetItems(int userId)
        {
            using var context = new DungeonCityContext();
            var result =
                from userItem in context.UserItem
                join item in context.Item on userItem.ItemId equals item.ItemId
                join itemType in context.ItemType on item.ItemTypeId equals itemType.ItemTypeId
                where userItem.UserId == userId
                select new ItemDto
                {
                    ItemId = item.ItemId,
                    UserItemId = userItem.UserItemId,
                    ItemDescription = item.ItemDescription,
                    ItemName = item.ItemName,
                    ItemPrice = item.ItemPrice,
                    ItemRarity = item.ItemRarity,
                    isEquipped = userItem.IsEquipped,
                    BaseMagical = item.BaseMagical,
                    BasePhysical = item.BasePhysical,
                    ItemType = itemType,
                    Attributes = (from itemAttribute in context.ItemAttribute.Where(t => t.UserItemId == userItem.UserItemId)
                                  from attribute in context.Attribute.Where(a => a.AttributeId == itemAttribute.AttributeId)
                                  select new Core.Entities.Concrete.Attribute { 
                                      AttributeId = attribute.AttributeId,
                                      Description = attribute.Description,
                                      Name = attribute.Name,
                                      Value = attribute.Value
                                  }
                                  ).ToList()
                };
            return result.ToList();
        }

        public void EquipItem(int userItemId)
        {
            using var context = new DungeonCityContext();
            var userItem = context.UserItem.Single(i => i.UserItemId == userItemId);
            if (userItem.IsEquipped)
            {
                userItem.IsEquipped = false;
            }
            else
            {
                userItem.IsEquipped = true;
            }
            _userItemDal.Update(userItem);
        }
    }
}