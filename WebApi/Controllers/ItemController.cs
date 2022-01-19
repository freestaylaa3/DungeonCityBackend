using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet(template:"get-items")]
        public ActionResult GetAll()
        {
            var result = _itemService.GetItems();
            if(result == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }


        [HttpGet(template:"get-itembyid")]
        public ActionResult GetById(int id)
        {
            var result = _itemService.GetById(id);
            if(result == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpPost(template: "add-item")]
        public IActionResult Add(Item item)
        {
            var result = _itemService.Add(item);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost(template: "update-item")]
        public IActionResult Update(Item item)
        {
            var result = _itemService.Update(item);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost(template: "delete-item")]
        public IActionResult Delete(Item item)
        {
            var result = _itemService.Delete(item);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
