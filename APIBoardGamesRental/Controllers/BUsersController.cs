using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBoardGamesRental.Models;
using APIBoardGamesRental.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIBoardGamesRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BUsersController : ControllerBase
    {
        private readonly BUsersService _busersService;

        public BUsersController(BUsersService busersService)
        {
            _busersService = busersService;
        }
        
        [HttpGet]
        public ActionResult<List<BUsers>> Get() =>
            _busersService.Get();
        
        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<BUsers> Get(string id)
        {
            var user = _busersService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        
        [HttpPost]
        public ActionResult<BUsers> Create(BUsers user)
        {
            _busersService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.oid.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, BUsers userIn)
        {
            var book = _busersService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _busersService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _busersService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _busersService.Remove(user.oid);

            return NoContent();
        }
    }
}
