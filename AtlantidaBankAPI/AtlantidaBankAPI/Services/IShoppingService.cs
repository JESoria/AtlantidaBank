using AtlantidaBankAPI.Models.DTOs;
using AtlantidaBankAPI.Models.Parameters;

namespace AtlantidaBankAPI.Services
{
    public interface IShoppingService
    {
        public Task<List<TransactionDTO>> AddPurchase(TransactionsModel model);

        public Task<List<TransactionDTO>> MakePayment(TransactionsModel model);
    }
}
