using AtlantidaBankAPI.Models.DTOs;
using AtlantidaBankAPI.Models.Parameters;

namespace AtlantidaBankAPI.Services
{
    public interface ICreditCardService
    {
        public Task<List<AccountStatementDetailDTO>> GetAccountDetail(AccountStatementDetailModel model);
        public Task<List<BonifiableInterestDTO>> CalculateBonifiableInterest(CreditCardModel model);
        public Task<List<CalculateMinimumPaymentDTO>> GetCalculateMinimumPayment(CreditCardModel model);
        public Task<List<CurrentMonthPurchasesDTO>> GetCurrentMonthPurchases(CreditCardModel model);
        public Task<List<TotalAmountToPayDTO>> GetTotalAmountToPay(CreditCardModel model);
        public Task<List<TotalCashAmountToPayWithInterestDTO>> GetTotalAmountToPayWithInterest(CreditCardModel model);
        public Task<List<TotalPurchasesDTO>> GetTotalPurchases(CreditCardModel model);
        public Task<List<TransactionsForCreditCardDTO>> GetAllTransactionsForCreditCard(CreditCardModel model);
    }
}
