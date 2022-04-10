
using Core.InterFaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basket;

        public BasketController(IBasketRepository basket)
        {
            _basket = basket;
        }
        [HttpGet]
      
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basket.GetBasketAsync(id);
            return Ok(basket?? new CustomerBasket(id));
        }
        [HttpPost]
        
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket= await _basket.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }
        [HttpDelete]
        public void DeleteBasket(string id)
        {
            _basket.DeleteBasketAsync(id);
        }
    }
}
