using AtlantidaBankCliente.Models;
using AtlantidaBankCliente.Models.ViewModels;

namespace AtlantidaBankCliente.Services
{
    public interface IShoppingService
    {
        Task<string> AddPurchase(TransactionViewModel model);

        Task<string> MakePayment(TransactionPayViewModel model);
    }
}
