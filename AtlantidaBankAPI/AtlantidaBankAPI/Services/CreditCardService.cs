using AtlantidaBankAPI.Models;
using AtlantidaBankAPI.Models.DTOs;
using AtlantidaBankAPI.Models.Parameters;
using AutoMapper;
using Ganss.Xss;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaBankAPI.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly AtlantidaBankContext _context;
        private readonly IMapper _mapper;
        private readonly HtmlSanitizer _htmlSanitizer;

        public CreditCardService(AtlantidaBankContext context, IMapper mapper, HtmlSanitizer htmlSanitizer)
        {
            this._context = context;
            this._mapper = mapper;
            this._htmlSanitizer = htmlSanitizer;
        }
        public async Task<List<BonifiableInterestDTO>> CalculateBonifiableInterest(CreditCardModel model)
        {
            var CrediCardId = _htmlSanitizer.Sanitize(model.CrediCardId.ToString());

            var crediCardidParameter = new SqlParameter("@CrediCardId", CrediCardId);

            var calculate = await _context.Set<SP_CalculateBonifiableInterest>().FromSqlRaw("EXEC SP_CalculateBonifiableInterest @CrediCardId", crediCardidParameter).ToListAsync();

            var mBonifiableInterest = _mapper.Map<List<BonifiableInterestDTO>>(calculate);

            return mBonifiableInterest;
        }

        public async Task<List<AccountStatementDetailDTO>> GetAccountDetail(AccountStatementDetailModel model)
        {
            var UserId = _htmlSanitizer.Sanitize(model.UserId.ToString());
            var CrediCardId = _htmlSanitizer.Sanitize(model.CrediCardId.ToString());

            var useridParameter = new SqlParameter("@UserId", UserId);
            var crediCardidParameter = new SqlParameter("@CrediCardId", CrediCardId);

            var accountStatementDetails = await _context.Set<SP_GetAccountStatementDetail>().FromSqlRaw("EXEC SP_GetAccountStatementDetail @UserId, @CrediCardId", useridParameter, crediCardidParameter).ToListAsync();

            var mAccountDeails = _mapper.Map<List<AccountStatementDetailDTO>>(accountStatementDetails);

            return mAccountDeails;
        }

        public async Task<List<TransactionsForCreditCardDTO>> GetAllTransactionsForCreditCard(CreditCardModel model)
        {
            var CrediCardId = _htmlSanitizer.Sanitize(model.CrediCardId.ToString());

            var crediCardidParameter = new SqlParameter("@CrediCardId", CrediCardId);

            var resultList = await _context.Set<SP_GetAllTransactionsForCreditCard>().FromSqlRaw("EXEC SP_GetAllTransactionsForCreditCard @CrediCardId", crediCardidParameter).ToListAsync();

            var mTransactions = _mapper.Map<List<TransactionsForCreditCardDTO>>(resultList);

            return mTransactions;
        }

        public async Task<List<CalculateMinimumPaymentDTO>> GetCalculateMinimumPayment(CreditCardModel model)
        {
            var CrediCardId = _htmlSanitizer.Sanitize(model.CrediCardId.ToString());

            var crediCardidParameter = new SqlParameter("@CrediCardId", CrediCardId);

            var calculateMinimumPayment = await _context.Set<SP_CalculateMinimumPayment>().FromSqlRaw("EXEC SP_CalculateMinimumPayment @CrediCardId", crediCardidParameter).ToListAsync();

            var mcalculateMinimumPayment = _mapper.Map<List<CalculateMinimumPaymentDTO>>(calculateMinimumPayment);

            return mcalculateMinimumPayment;
        }

        public async Task<List<CurrentMonthPurchasesDTO>> GetCurrentMonthPurchases(CreditCardModel model)
        {
            var CrediCardId = _htmlSanitizer.Sanitize(model.CrediCardId.ToString());

            var crediCardidParameter = new SqlParameter("@CrediCardId", CrediCardId);

            var currentMonthPurchases = await _context.Set<SP_GetCurrentMonthPurchases>().FromSqlRaw("EXEC SP_GetCurrentMonthPurchases @CrediCardId", crediCardidParameter).ToListAsync();


            var mCurrentPurchases = _mapper.Map<List<CurrentMonthPurchasesDTO>>(currentMonthPurchases);

            return mCurrentPurchases;
        }

        public async Task<List<TotalAmountToPayDTO>> GetTotalAmountToPay(CreditCardModel model)
        {
            var CrediCardId = _htmlSanitizer.Sanitize(model.CrediCardId.ToString());

            var crediCardidParameter = new SqlParameter("@CrediCardId", CrediCardId);

            var calculate = await _context.Set<SP_CalculateTotalAmountToPay>().FromSqlRaw("EXEC SP_CalculateTotalAmountToPay @CrediCardId", crediCardidParameter).ToListAsync();

            var mTotalAmountToPay = _mapper.Map<List<TotalAmountToPayDTO>>(calculate);

            return mTotalAmountToPay;
        }

        public async Task<List<TotalCashAmountToPayWithInterestDTO>> GetTotalAmountToPayWithInterest(CreditCardModel model)
        {
            var CrediCardId = _htmlSanitizer.Sanitize(model.CrediCardId.ToString());

            var crediCardidParameter = new SqlParameter("@CrediCardId", CrediCardId);

            var calculate = await _context.Set<SP_TotalCashAmountToPayWithInterest>().FromSqlRaw("EXEC SP_TotalCashAmountToPayWithInterest @CrediCardId", crediCardidParameter).ToListAsync();

            var mTotalCashAmountToPayWithInterest = _mapper.Map<List<TotalCashAmountToPayWithInterestDTO>>(calculate);

            return mTotalCashAmountToPayWithInterest;
        }

        public async Task<List<TotalPurchasesDTO>> GetTotalPurchases(CreditCardModel model)
        {
            var CrediCardId = _htmlSanitizer.Sanitize(model.CrediCardId.ToString());

            var crediCardidParameter = new SqlParameter("@CrediCardId", CrediCardId);

            var totalPurchases = await _context.Set<SP_GetTotalPurchases>().FromSqlRaw("EXEC SP_GetTotalPurchases @CrediCardId", crediCardidParameter).ToListAsync();

            var mtotalPurchases = _mapper.Map<List<TotalPurchasesDTO>>(totalPurchases);

            return mtotalPurchases;
        }
    }
}
