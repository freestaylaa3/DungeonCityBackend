
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<ItemDto> GetItems(int userId);
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<User>> GetAllUsers();
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        User GetByMail(string email);
        User GetById(int id);
        User GetByUserName(string name);
        void AddItem(int itemId, int userId);
        void DeleteItem(int userItemId);
        void UpdateItem(UserItem userItem);
        void EquipItem(int userItemId);
    }
}
