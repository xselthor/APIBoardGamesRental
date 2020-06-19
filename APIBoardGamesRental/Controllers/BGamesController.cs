using APIBoardGamesRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using APIBoardGamesRental.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using JsonConvert = MongoDB.Bson.IO.JsonConvert;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace APIBoardGamesRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BGamesController : ControllerBase
    {
        private readonly BGamesService _bgameService;

        public BGamesController(BGamesService bgameService)
        {
            _bgameService = bgameService;
        }

        [HttpGet]
        public ActionResult<List<BGames>> Get() =>
            _bgameService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBGame")]
        public ActionResult<BGames> Get(string id)
        {
            var bgame = _bgameService.Get(id);

            if (bgame == null)
            {
                return NotFound();
            }

            return bgame;
        }

        [HttpPost]
        public ActionResult<BGames> Create(BGames bgame)
        {
            _bgameService.Create(bgame);

            return CreatedAtRoute("GetBook", new { id = bgame.oid.ToString() }, bgame);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, BGames bgameIn)
        {
            //Console.WriteLine(bgameIn.Count);
            var gdata = Newtonsoft.Json.JsonConvert.SerializeObject(bgameIn);
            Console.WriteLine(gdata);
            
            var bgame = _bgameService.Get(id);

            if (bgame == null)
            {
                return NotFound();
            }

            _bgameService.Update(id, bgameIn);
            

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var bgame = _bgameService.Get(id);

            if (bgame == null)
            {
                return NotFound();
            }

            _bgameService.Remove(bgame.oid);

            return NoContent();
        }
    }
}
