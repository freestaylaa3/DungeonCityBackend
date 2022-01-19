 using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;


        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);

            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(message: Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.UserPasswordHash, userToCheck.UserPasswordSalt))
            {
                return new ErrorDataResult<User>(message: Messages.PasswordError);
            }
            userToCheck.LastLogin = DateTime.Now;
            _userService.Update(userToCheck);
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                UserName = userForRegisterDto.UserName,
                UserEmail = userForRegisterDto.Email,
                UserPasswordHash = passwordHash,
                UserPasswordSalt = passwordSalt,
                CreateTime = DateTime.Now,
                LastLogin = DateTime.Now,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email,string name)
        {
            if(_userService.GetByUserName(name)!= null)
            {
                return new ErrorResult(message: Messages.UserAlreadyExists);
            }
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(message: Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
