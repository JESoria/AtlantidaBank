using AtlantidaBankCliente.Models.ViewModels;
using AtlantidaBankCliente.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AtlantidaBankCliente.Controllers
{
    public class HomeController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly SessionService _sessionService;

        public HomeController(TokenService tokenService, SessionService sessionService)
        {
            this._tokenService = tokenService;
            this._sessionService = sessionService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                AddErrorsFromModel(ModelState.Values);
                return View();
            }

            try
            {
                var mUser = await _tokenService.GetToken(model);
                
                if (mUser.Token is null)
                {
                    TempData["Message"] = "Credenciales Invalidas";
                    return View();
                }
                //Save sesion
                _sessionService.SaveSession(mUser);

                return RedirectToAction("Main", "Home", null);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Hubo un error al procesar la solicitud. Error: " + ex.Message + " Detalle Error: " + ex.InnerException });
            }

        }

        [HttpGet]
        public IActionResult Main()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _sessionService.CloseSession();
            return RedirectToAction("Index", "Home");
        }

        private void AddErrorsFromModel(ModelStateDictionary.ValueEnumerable values)
        {
            foreach (ModelStateEntry modelState in values)
                foreach (ModelError error in modelState.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.ErrorMessage.ToString());

                }
        }

        [HttpGet]
        public IActionResult Error(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }

    }
}
