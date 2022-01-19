
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void AddItem(int itemId ,int userId)
        {
            _userDal.AddItem(itemId, userId);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public void DeleteItem(int userItemId)
        {
            _userDal.DeleteItem(userItemId);
        }

        public void EquipItem(int userItemId)
        {
            _userDal.EquipItem(userItemId);
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList().ToList());
        }

        public User GetById(int id)
        {
            return _userDal.Get(filter: u => u.UserId == id);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(filter: u => u.UserEmail == email);
        }

        public User GetByUserName(string name)
        {
            return _userDal.Get(filter: u => u.UserName == name);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public List<ItemDto> GetItems(int userId)
        {
            return _userDal.GetItems(userId);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public void UpdateItem(UserItem userItem)
        {
            _userDal.UpdateItem(userItem);
        }
    }
}
