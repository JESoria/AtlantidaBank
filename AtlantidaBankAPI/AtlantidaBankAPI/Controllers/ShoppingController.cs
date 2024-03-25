using AtlantidaBankAPI.Models.Parameters;
using AtlantidaBankAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlantidaBankAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class ShoppingController : Controller
    {
        private readonly ShoppingService _service;

        public ShoppingController(ShoppingService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("AddPurchase")]
        public async Task<IActionResult> AddPurchase(TransactionsModel model)
        {
            if (ModelState.IsValid)
            {
                if (model is not null)
                {
                    var mMessage = await _service.AddPurchase(model);

                    if (mMessage.Count > 0)
                    {
                        return Ok(mMessage.FirstOrDefault());
                    }
                    else
                        return NotFound(mMessage);

                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("MakePayment")]
        public async Task<IActionResult> MakePayment(TransactionsModel model)
        {
            if (ModelState.IsValid)
            {
                if (model is not null)
                {
                    var mMessage = await _service.MakePayment(model);

                    if (mMessage.Count > 0)
                    {
                        return Ok(mMessage.FirstOrDefault());
                    }
                    else
                        return NotFound(mMessage);

                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }
    }

}
