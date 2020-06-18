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
    public class BBasketController : ControllerBase
    {
        private readonly BBasketService _bbasketService;

        public BBasketController(BBasketService bbasketService)
        {
            _bbasketService = bbasketService;
        }

        [HttpGet]
        public ActionResult<List<BBasket>> Get() =>
            _bbasketService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBBasket")]
        public ActionResult<BBasket> Get(string id)
        {
            var bbasket = _bbasketService.Get(id);

            if (bbasket == null)
            {
                return NotFound();
            }

            return bbasket;
        }
    }
}
