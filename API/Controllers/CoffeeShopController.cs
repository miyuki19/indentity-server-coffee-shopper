using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
