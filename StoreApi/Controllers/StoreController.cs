using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationTier;
using ApplicationTier.Interfaces;
using ApplicationTier.Classes;
using ApplicationTier.Dtos;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        public readonly IStoreMethods _storeMethods;

        public StoreController(IStoreMethods storeMethods)
        {
            _storeMethods = storeMethods;
        }

        [HttpGet]
        public async Task<JsonResult> Store(int StoreId)
        {

            var store = await _storeMethods.GetStore(StoreId);

            return new JsonResult(store);

        }

    }

    
}
