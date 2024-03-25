namespace AtlantidaBankAPI.Models.DTOs
{
    public class CurrentMonthPurchasesDTO
    {
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
