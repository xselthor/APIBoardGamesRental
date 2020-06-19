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
    public class BUnitController : ControllerBase
    {
        private readonly BUnitService _bunitService;

        public BUnitController(BUnitService bunitService)
        {
            _bunitService = bunitService;
        }

        [HttpGet]
        public ActionResult<List<BUnit>> Get() =>
            _bunitService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBUnit")]
        public ActionResult<BUnit> Get(string id)
        {
            var bunit = _bunitService.Get(id);

            if (bunit == null)
            {
                return NotFound();
            }

            return bunit;
        }

        [HttpPost]
        public ActionResult<BUnit> Create(BUnit bunit)
        {
            _bunitService.Create(bunit);

            return CreatedAtRoute("GetUnit", new { id = bunit.oid.ToString() }, bunit);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, BUnit bunitIn)
        {
            var gdata = Newtonsoft.Json.JsonConvert.SerializeObject(bunitIn);
            Console.WriteLine(gdata);

            var bunit = _bunitService.Get(id);

            if (bunit == null)
            {
                return NotFound();
            }

            _bunitService.Update(id, bunitIn);


            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var bunit = _bunitService.Get(id);

            if (bunit == null)
            {
                return NotFound();
            }

            _bunitService.Remove(bunit.oid);

            return NoContent();
        }
    }
}
