﻿using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeShopController : ControllerBase
    {
        private readonly ICoffeeShopService _coffeeShopService;

        public CoffeeShopController(ICoffeeShopService coffeeShopService)
        {
            this._coffeeShopService = coffeeShopService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoffeeShops()
        {
            var cofeeShops = await _coffeeShopService.GetCoffeeShopList();
            return Ok(cofeeShops);
        }
    }
}
