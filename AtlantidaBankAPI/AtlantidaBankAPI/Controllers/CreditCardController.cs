using AtlantidaBankAPI.Models.Parameters;
using AtlantidaBankAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlantidaBankAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class CreditCardController : Controller
    {
        private readonly CreditCardService _service;

        public CreditCardController(CreditCardService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("GetBonifiableInterest")] //OKKKKKKKKKKK
        public async Task<IActionResult> GetBonifiableInterest(CreditCardModel model)
        {
            if (ModelState.IsValid)
            {
                if (model is not null)
                {
                    var mBonifiableInterest = await _service.CalculateBonifiableInterest(model);

                    if (mBonifiableInterest.Count > 0)
                    {
                        return Ok(mBonifiableInterest.FirstOrDefault());
                    }
                    else
                        return NotFound("No hay datos relacionados");

                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("GetCalculateMinimumPayment")] //OKKKK
        public async Task<IActionResult> GetCalculateMinimumPayment(CreditCardModel model)
        {
            if (ModelState.IsValid)
            {
                if (model is not null)
                {
                    var mCurrentPurchases = await _service.GetCalculateMinimumPayment(model);

                    if (mCurrentPurchases.Count > 0)
                    {
                        return Ok(mCurrentPurchases.FirstOrDefault());
                    }
                    else
                        return NotFound("No hay datos relacionados");

                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("GetCurrentPurchases")] //Historial de Transacciones del mes
        public async Task<IActionResult> GetCurrentMonthPurchases(CreditCardModel model)
        {
            if (ModelState.IsValid)
            {
                if (model is not null)
                {
                    var mCurrentPurchases = await _service.GetCurrentMonthPurchases(model);

                    if (mCurrentPurchases.Count > 0)
                    {
                        return Ok(mCurrentPurchases.ToList());
                    }
                    else
                        return NotFound("No hay datos relacionados");

                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("GetAccount")] //OKKKKKKKKKKKKKKKK
        public async Task<IActionResult> GetAccountStatementDetail(AccountStatementDetailModel model)
        {
            if (ModelState.IsValid)
            {
                if (model is not null)
                {

                    var mDetail = await _service.GetAccountDetail(model);

                    if (mDetail.Count > 0)
                    {
                        return Ok(mDetail.FirstOrDefault());
                    }
                    else
                        return NotFound("No hay datos relacionados");

                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("GetTotalAmountToPay")] //OKKKK
        public async Task<IActionResult> GetTotalAmountToPay(CreditCardModel model)
        {
            if (ModelState.IsValid)
            {
                if (model is not null)
                {
                    var mTotalAmountToPay = await _service.GetTotalAmountToPay(model);

                    if (mTotalAmountToPay.Count > 0)
                    {
                        return Ok(mTotalAmountToPay.FirstOrDefault());
                    }
                    else
                        return NotFound("No hay datos relacionados");

                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("GetTotalCashAmountToPayWithInterest")] //OKKKKKKKKKKKK
        public async Task<IActionResult> GetTotalCashAmountToPayWithInterest(CreditCardModel model)
        {
            if (ModelState.IsValid)
            {
                if (model is not null)
                {

                    var mTotalCashAmountToPayWithInterest = await _service.GetTotalAmountToPayWithInterest(model);

                    if (mTotalCashAmountToPayWithInterest.Count > 0)
                    {
                        return Ok(mTotalCashAmountToPayWithInterest.FirstOrDefault());
                    }
                    else
                        return NotFound("No hay datos relacionados");

                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("GetTotalPurchases")] //OKKKKKKKKKKKKKKKK
        public async Task<IActionResult> GetTotalPurchases(CreditCardModel model)
        {
            if (ModelState.IsValid)
            {
                if (model is not null)
                {

                    var mTotalPurchases = await _service.GetTotalPurchases(model);

                    if (mTotalPurchases.Count > 0)
                    {
                        return Ok(mTotalPurchases.FirstOrDefault());
                    }
                    else
                        return NotFound("No hay datos relacionados");


                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("GetAllTransactionsForCreditCard")]
        public async Task<IActionResult> GetAllTransactionsForCreditCard(CreditCardModel model)
        {
            if (ModelState.IsValid)
            {
                if (model is not null)
                {

                    var mTransactions = await _service.GetAllTransactionsForCreditCard(model);

                    if (mTransactions.Count > 0)
                    {
                        return Ok(mTransactions.ToList());
                    }
                    else
                        return NotFound("No hay datos");


                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

    }
}
