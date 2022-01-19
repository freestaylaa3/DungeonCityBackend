using Business.Abstract;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Hashing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(template:"get-users")]
        public ActionResult GetUsers()
        {
            var result = _userService.GetAllUsers();
            return Ok(result.Data);
        }

        [HttpGet(template: "get-items")]
        public ActionResult GetItems(int id)
        {
            var result = _userService.GetItems(id);
            return Ok(result);
        }

        [HttpGet(template:"getbyid")]
        public ActionResult GetById(int id)
        {
            
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost(template:"delete-user")]
        public ActionResult DeleteUser(int id)
        {
            var user = _userService.GetById(id);
            _userService.Delete(user);
            return Ok();
        }

        [HttpPost(template: "add-item")]
        public ActionResult AddItem(int itemId, int userId )
        {
            _userService.AddItem(itemId, userId);
            return Ok();
        }

        [HttpPost(template: "delete-item")]
        public ActionResult DeleteItem(int userItemId)
        {
            _userService.DeleteItem(userItemId);
            return Ok();
        }

        [HttpPost(template: "equip-item")]
        public ActionResult EquipItem(int userItemId)
        {
            _userService.EquipItem(userItemId);
            return Ok();
        }

        [HttpPost(template: "update-item")]
        public ActionResult UpdateItem(UserItem userItem)
        {
            _userService.UpdateItem(userItem);
            return Ok();
        }

        [HttpPost(template: "update-user")]
        public ActionResult UpdateUser(User user)
        {
            _userService.Update(user);
            return Ok();
        }

    }
}
