using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<ItemDto> GetItems(int userId);
        void AddItem(int itemId, int userId);
        void DeleteItem(int userItemId);
        void EquipItem(int userItemId);
        void UpdateItem(UserItem userItem);
    }
}
