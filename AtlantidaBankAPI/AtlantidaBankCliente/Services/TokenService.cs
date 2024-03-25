
using AtlantidaBankCliente.Models;
using AtlantidaBankCliente.Models.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace AtlantidaBankCliente.Services
{
    public class TokenService : ItokenService
    {
        public async Task<TokenModel> GetToken(LoginViewModel model)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(RoutesAPI.API_PATH);

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(RoutesAPI.GET_TOKEN, content);


            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<TokenModel>(jsonResponse);

                return result;
            }
            else
                return new TokenModel();

        }
    }
}
