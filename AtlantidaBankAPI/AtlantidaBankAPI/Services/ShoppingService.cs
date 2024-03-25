using AtlantidaBankAPI.Models;
using AtlantidaBankAPI.Models.DTOs;
using AtlantidaBankAPI.Models.Parameters;
using AutoMapper;
using Ganss.Xss;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaBankAPI.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly AtlantidaBankContext _context;
        private readonly IMapper _mapper;
        private readonly HtmlSanitizer _htmlSanitizer;

        public ShoppingService(AtlantidaBankContext context, IMapper mapper, HtmlSanitizer htmlSanitizer)
        {
            this._context = context;
            this._mapper = mapper;
            this._htmlSanitizer = htmlSanitizer;
        }
        public async Task<List<TransactionDTO>> AddPurchase(TransactionsModel model)
        {
            var CrediCardId = _htmlSanitizer.Sanitize(model.CrediCardId.ToString());
            var TransactionDate = _htmlSanitizer.Sanitize(model.TransactionDate.ToString());
            var Description = _htmlSanitizer.Sanitize(model.Description.ToString());
            var Amount = _htmlSanitizer.Sanitize(model.Amount.ToString());
            var IPAddress = _htmlSanitizer.Sanitize(model.IPAddress.ToString());

            var crediCardidParameter = new SqlParameter("@CrediCardId", CrediCardId);
            var TransactionDateParameter = new SqlParameter("@TransactionDate", TransactionDate);
            var DescriptionParameter = new SqlParameter("@Description", Description);
            var AmountParameter = new SqlParameter("@Amount", Amount);
            var IPAddressParameter = new SqlParameter("@IPAddress", IPAddress);

            var calculate = await _context.Set<SP_AddPurchase>()
                .FromSqlRaw(
                "EXEC SP_AddPurchase @CrediCardId,@TransactionDate,@Description,@Amount,@IPAddress",
                crediCardidParameter, TransactionDateParameter, DescriptionParameter, AmountParameter, IPAddressParameter).ToListAsync();

            var mMessage = _mapper.Map<List<TransactionDTO>>(calculate);

            return mMessage;
        }

        public async Task<List<TransactionDTO>> MakePayment(TransactionsModel model)
        {
            var CrediCardId = _htmlSanitizer.Sanitize(model.CrediCardId.ToString());
            var TransactionDate = _htmlSanitizer.Sanitize(model.TransactionDate.ToString());
            var Description = _htmlSanitizer.Sanitize(model.Description.ToString());
            var Amount = _htmlSanitizer.Sanitize(model.Amount.ToString());
            var IPAddress = _htmlSanitizer.Sanitize(model.IPAddress.ToString());

            var crediCardidParameter = new SqlParameter("@CrediCardId", CrediCardId);
            var TransactionDateParameter = new SqlParameter("@TransactionDate", TransactionDate);
            var DescriptionParameter = new SqlParameter("@Description", Description);
            var AmountParameter = new SqlParameter("@Amount", Amount);
            var IPAddressParameter = new SqlParameter("@IPAddress", IPAddress);

            var calculate = await _context.Set<SP_MakePayment>()
                .FromSqlRaw(
                "EXEC SP_MakePayment @CrediCardId,@TransactionDate,@Description,@Amount,@IPAddress",
                crediCardidParameter, TransactionDateParameter, DescriptionParameter, AmountParameter, IPAddressParameter).ToListAsync();

            var mMessage = _mapper.Map<List<TransactionDTO>>(calculate);

            return mMessage;
        }
    }
}
