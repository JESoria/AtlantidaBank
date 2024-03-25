using AtlantidaBankCliente.Models;
using AtlantidaBankCliente.Models.ViewModels;
using AtlantidaBankCliente.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AtlantidaBankCliente.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly SessionService _sessionService;
        private readonly ShoppingService _shoppingService;

        public ShoppingController(SessionService sessionService, ShoppingService shoppingService)
        {
            this._sessionService = sessionService;
            this._shoppingService = shoppingService;
        }

        [HttpGet]
        public IActionResult AddPurchase()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPurchase(TransactionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                AddErrorsFromModel(ModelState.Values);
                return View();
            }

            try
            {
                var session = _sessionService.GetSession();

                model.IPAddress = session.IPAddress;
                model.CrediCardId = session.CrediCardId.ToString();

                var mMessage = await _shoppingService.AddPurchase(model);

                TempData["Message"] = mMessage;

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Hubo un error al procesar la solicitud. Error: " + ex.Message + " Detalle Error: " + ex.InnerException });
            }
  
        }


        [HttpGet]
        public IActionResult MakePayment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakePayment(TransactionPayViewModel model)
        {

            if (!ModelState.IsValid)
            {
                AddErrorsFromModel(ModelState.Values);
                return View();
            }

            try
            {
                var session = _sessionService.GetSession();

                model.IPAddress = session.IPAddress;
                model.CrediCardId = session.CrediCardId.ToString();
                model.Description = "Realización de pago";


                var mMessage = await _shoppingService.MakePayment(model);

                TempData["Message"] = mMessage;

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Hubo un error al procesar la solicitud. Error: " + ex.Message + " Detalle Error: " + ex.InnerException });
            }
            
        }


        private void AddErrorsFromModel(ModelStateDictionary.ValueEnumerable values)
        {
            foreach (ModelStateEntry modelState in values)
                foreach (ModelError error in modelState.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.ErrorMessage.ToString());

                }
        }

    }
}
