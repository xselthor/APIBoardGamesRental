using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBoardGamesRental.Models;
using APIBoardGamesRental.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBoardGamesRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BOrderController : ControllerBase
    {
        private readonly BOrderService _borderService;

        public BOrderController(BOrderService borderService)
        {
            _borderService = borderService;
        }

        [HttpGet]
        public ActionResult<List<BOrder>> Get() =>
            _borderService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBOrder")]
        public ActionResult<BOrder> Get(string id)
        {
            var bunit = _borderService.Get(id);

            if (bunit == null)
            {
                return NotFound();
            }

            return bunit;
        }

        [HttpPost]
        public ActionResult<BOrder> Create(BOrder border)
        {
            _borderService.Create(border);

            return CreatedAtRoute("GetOrder", new { id = border.oid.ToString() }, border);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, BOrder borderIn)
        {
            var gdata = Newtonsoft.Json.JsonConvert.SerializeObject(borderIn);
            Console.WriteLine(gdata);

            var border = _borderService.Get(id);

            if (border == null)
            {
                return NotFound();
            }

            _borderService.Update(id, borderIn);


            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var border = _borderService.Get(id);

            if (border == null)
            {
                return NotFound();
            }

            _borderService.Remove(border.oid);

            return NoContent();
        }
    }
}
