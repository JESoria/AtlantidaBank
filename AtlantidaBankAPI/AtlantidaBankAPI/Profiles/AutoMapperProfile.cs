using AtlantidaBankAPI.Models;
using AtlantidaBankAPI.Models.DTOs;
using AutoMapper;

namespace AtlantidaBankAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, SP_Login>();
            CreateMap<SP_Login, UserDTO>();

            CreateMap<AccountStatementDetailDTO, SP_GetAccountStatementDetail>();
            CreateMap<SP_GetAccountStatementDetail, AccountStatementDetailDTO>();

            CreateMap<CurrentMonthPurchasesDTO, SP_GetCurrentMonthPurchases>();
            CreateMap<SP_GetCurrentMonthPurchases, CurrentMonthPurchasesDTO>();

            CreateMap<TotalPurchasesDTO, SP_GetTotalPurchases>();
            CreateMap<SP_GetTotalPurchases, TotalPurchasesDTO>();

            CreateMap<BonifiableInterestDTO, SP_CalculateBonifiableInterest>();
            CreateMap<SP_CalculateBonifiableInterest, BonifiableInterestDTO>();

            CreateMap<CalculateMinimumPaymentDTO, SP_CalculateMinimumPayment>();
            CreateMap<SP_CalculateMinimumPayment, CalculateMinimumPaymentDTO>();

            CreateMap<TotalAmountToPayDTO, SP_CalculateTotalAmountToPay>();
            CreateMap<SP_CalculateTotalAmountToPay, TotalAmountToPayDTO>();

            CreateMap<TotalCashAmountToPayWithInterestDTO, SP_TotalCashAmountToPayWithInterest>();
            CreateMap<SP_TotalCashAmountToPayWithInterest, TotalCashAmountToPayWithInterestDTO>();

            CreateMap<TransactionDTO, SP_AddPurchase>();
            CreateMap<SP_AddPurchase, TransactionDTO>();

            CreateMap<TransactionDTO, SP_MakePayment>();
            CreateMap<SP_MakePayment, TransactionDTO>();

            CreateMap<TransactionsForCreditCardDTO, SP_GetAllTransactionsForCreditCard>();
            CreateMap<SP_GetAllTransactionsForCreditCard, TransactionsForCreditCardDTO>();
        }
       
    }
}
