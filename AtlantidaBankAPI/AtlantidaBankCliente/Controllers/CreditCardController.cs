using AtlantidaBankCliente.Models;
using AtlantidaBankCliente.Models.ViewModels;
using AtlantidaBankCliente.Services;
using Microsoft.AspNetCore.Mvc;

namespace AtlantidaBankCliente.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly SessionService _sessionService;
        private readonly CreditCardService _creditCardService;
        private readonly ILogger<CreditCardController> _logger;

        public CreditCardController(SessionService sessionService, CreditCardService creditCardService, ILogger<CreditCardController> logger)
        {
            this._sessionService = sessionService;
            this._creditCardService = creditCardService;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> AccountStatus()
        {
            try
            {
                //Obteniendo datos de la cuenta
                var session = _sessionService.GetSession();
                AccountStatementDetailModel model = new AccountStatementDetailModel()
                {
                    UserId = session.UserId.ToString(),
                    CrediCardId = session.CrediCardId.ToString()
                };

                CreditCardModel creditCardModel = new CreditCardModel()
                {
                    CrediCardId = session.CrediCardId.ToString()
                };

                _logger.LogInformation("Obteniendo datos de la tarjeta de credito");

                var AccountStatementDetail = await _creditCardService.GetAccountStatementDetail(model);
                ViewBag.AccountStatementDetail = AccountStatementDetail;

                var TotalPurchases = await _creditCardService.GetTotalPurchases(creditCardModel);
                ViewBag.TotalPurchases = TotalPurchases;

                var BonifiableInterest = await _creditCardService.GetBonifiableInterest(creditCardModel);
                ViewBag.BonifiableInterest = BonifiableInterest.BonifiableInterest;

                var MinimumPayment = await _creditCardService.GetCalculateMinimumPayment(creditCardModel);
                ViewBag.MinimumPayment = MinimumPayment.MinimumPayment;

                var TotalAmountToPay = await _creditCardService.GetTotalAmountToPay(creditCardModel);
                ViewBag.TotalAmountToPay = TotalAmountToPay.TotalAmountToPay;

                var TotalAmountToPayWithInterest = await _creditCardService.GetTotalAmountToPayWithInterest(creditCardModel);
                ViewBag.TotalAmountToPayWithInterest = TotalAmountToPayWithInterest.TotalCashAmountToPayWithInterest;

                var ListCurrentMonthPurchases = await _creditCardService.GetCurrentMonthPurchases(creditCardModel);
                ViewBag.ListCurrentMonthPurchases = ListCurrentMonthPurchases;

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error","Home", new { errorMessage = "Hubo un error al procesar la solicitud. Error: " + ex.Message + " Detalle Error: " + ex.InnerException } );
            }
        }

        [HttpGet]
        public async Task<IActionResult> Transactions()
        {
            try
            {
                //Obteniendo datos de la cuenta
                var session = _sessionService.GetSession();

                CreditCardModel creditCardModel = new CreditCardModel()
                {
                    CrediCardId = session.CrediCardId.ToString()
                };

                var AllTransactions = await _creditCardService.GetAllTransactionsForCreditCard(creditCardModel);
                ViewBag.AllTransactions = AllTransactions;

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Hubo un error al procesar la solicitud. Error: " + ex.Message + " Detalle Error: " + ex.InnerException });
            }
            
        }
    }
}
