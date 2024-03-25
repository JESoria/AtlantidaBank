using AtlantidaBankCliente.Models;
using AtlantidaBankCliente.Models.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AtlantidaBankCliente.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly SessionService _sessionService;

        public CreditCardService(SessionService sessionService) 
        {
            this._sessionService = sessionService;
        }

        public async Task<AccountStatementDetailViewModel> GetAccountStatementDetail(AccountStatementDetailModel model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(RoutesAPI.API_PATH);
            var session = _sessionService.GetSession();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(RoutesAPI.GET_ACCOUNT_STATEMENT_DETAIL, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AccountStatementDetailViewModel>(jsonResponse);

                return result;
            }else
                return new AccountStatementDetailViewModel();
        }

        public async Task<TotalPurchasesViewModel> GetTotalPurchases(CreditCardModel model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(RoutesAPI.API_PATH);
            var session = _sessionService.GetSession();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(RoutesAPI.GET_TOTAL_PURCHASES, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TotalPurchasesViewModel>(jsonResponse);

                return result;
            }
            else
                return new TotalPurchasesViewModel();
        }

        public async Task<BonifiableInterestViewModel> GetBonifiableInterest(CreditCardModel model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(RoutesAPI.API_PATH);
            var session = _sessionService.GetSession();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(RoutesAPI.GET_BONIFIABLE_INTEREST, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BonifiableInterestViewModel>(jsonResponse);

                return result;
            }
            else
                return new BonifiableInterestViewModel();
        }

        public async Task<MinimumPaymentViewModel> GetCalculateMinimumPayment(CreditCardModel model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(RoutesAPI.API_PATH);
            var session = _sessionService.GetSession();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(RoutesAPI.GET_MINIMUN_PAYMENT, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<MinimumPaymentViewModel>(jsonResponse);

                return result;
            }
            else
                return new MinimumPaymentViewModel();
        }

        public async Task<TotalAmountToPayViewModel> GetTotalAmountToPay(CreditCardModel model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(RoutesAPI.API_PATH);
            var session = _sessionService.GetSession();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(RoutesAPI.GET_TOTAL_AMOUNT_TO_PAY, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TotalAmountToPayViewModel>(jsonResponse);

                return result;
            }
            else
                return new TotalAmountToPayViewModel();
        }

        public async Task<TotalCashAmountToPayWithInterestViewModel> GetTotalAmountToPayWithInterest(CreditCardModel model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(RoutesAPI.API_PATH);
            var session = _sessionService.GetSession();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(RoutesAPI.GET_TOTAL_AMOUNT_TO_PAY_WITH_INTEREST, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TotalCashAmountToPayWithInterestViewModel>(jsonResponse);

                return result;
            }
            else
                return new TotalCashAmountToPayWithInterestViewModel();
        }

        public async Task<List<CurrentMonthPurchasesViewModel>> GetCurrentMonthPurchases(CreditCardModel model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(RoutesAPI.API_PATH);
            var session = _sessionService.GetSession();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(RoutesAPI.GET_CURRENT_PURCHASES, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<CurrentMonthPurchasesViewModel>>(jsonResponse);

                return result;
            }
            else
                return new List<CurrentMonthPurchasesViewModel>();
        }

        public async Task<List<TransactionsForCreditCardViewModel>> GetAllTransactionsForCreditCard(CreditCardModel model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(RoutesAPI.API_PATH);
            var session = _sessionService.GetSession();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(RoutesAPI.GET_ALL_TRANSACTIONS, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<TransactionsForCreditCardViewModel>>(jsonResponse);

                return result;
            }
            else
                return new List<TransactionsForCreditCardViewModel>();
        }
    }
    
}
