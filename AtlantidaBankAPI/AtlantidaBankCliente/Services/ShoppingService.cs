using AtlantidaBankCliente.Models;
using AtlantidaBankCliente.Models.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AtlantidaBankCliente.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly SessionService _sessionService;

        public ShoppingService(SessionService sessionService)
        {
            this._sessionService = sessionService;
        }
        public async Task<string> AddPurchase(TransactionViewModel model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(RoutesAPI.API_PATH);
            var session = _sessionService.GetSession();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(RoutesAPI.ADD_PURCHASE, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TransactionViewModel>(jsonResponse);

                return result.Message;
            }
            else
                return "";
        }

        public async Task<string> MakePayment(TransactionPayViewModel model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(RoutesAPI.API_PATH);
            var session = _sessionService.GetSession();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(RoutesAPI.MAKE_PAYMENT, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TransactionViewModel>(jsonResponse);

                return result.Message;
            }
            else
                return "";
        }
    }
}
