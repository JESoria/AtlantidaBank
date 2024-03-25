using AtlantidaBankCliente.Models;
using AtlantidaBankCliente.Models.ViewModels;

namespace AtlantidaBankCliente.Services
{
    public interface ICreditCardService
    {
        Task<AccountStatementDetailViewModel> GetAccountStatementDetail(AccountStatementDetailModel model);
        Task<TotalPurchasesViewModel> GetTotalPurchases(CreditCardModel model);
        Task<BonifiableInterestViewModel> GetBonifiableInterest(CreditCardModel model);
        Task<MinimumPaymentViewModel> GetCalculateMinimumPayment(CreditCardModel model);
        Task<TotalAmountToPayViewModel> GetTotalAmountToPay(CreditCardModel model);
        Task<TotalCashAmountToPayWithInterestViewModel> GetTotalAmountToPayWithInterest(CreditCardModel model);
        Task<List<CurrentMonthPurchasesViewModel>> GetCurrentMonthPurchases(CreditCardModel model);
        Task<List<TransactionsForCreditCardViewModel>> GetAllTransactionsForCreditCard(CreditCardModel model);
    }
}
