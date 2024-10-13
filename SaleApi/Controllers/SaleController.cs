using ApplicationTier.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleMethods _saleMethods;

        public SaleController(ISaleMethods saleMethods)
        {
            _saleMethods = saleMethods;
        }

        [HttpPost(Name = "AddSale")]
        public async Task<JsonResult> AddSale(int customerID, int productId, int storeID, DateTime dateSold)
        {
            try
            {
                return new JsonResult(await _saleMethods.AddSaleAsync(customerID, productId, storeID, dateSold));
            }
            catch (Exception ex) 
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}
