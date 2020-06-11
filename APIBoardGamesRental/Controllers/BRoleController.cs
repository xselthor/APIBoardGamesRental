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
    public class BRoleController : ControllerBase
    {
        private readonly BRoleService _broleService;

        public BRoleController(BRoleService broleService)
        {
            _broleService = broleService;
        }

        [HttpGet]
        public ActionResult<List<BRole>> Get() =>
            _broleService.Get();

        [HttpGet("{id:length(24)}", Name = "GetRole")]
        public ActionResult<BRole> Get(string id)
        {
            var role = _broleService.Get(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpPost]
        public ActionResult<BRole> Create(BRole role)
        {
            _broleService.Create(role);

            return CreatedAtRoute("GetRole", new { id = role.oid.ToString() }, role);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, BRole roleIn)
        {
            var role = _broleService.Get(id);

            if (role == null)
            {
                return NotFound();
            }

            _broleService.Update(id, roleIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var role = _broleService.Get(id);

            if (role == null)
            {
                return NotFound();
            }

            _broleService.Remove(role.oid);

            return NoContent();
        }
    }
}
