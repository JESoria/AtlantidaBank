namespace AtlantidaBankAPI.Models
{
    public class SP_GetCurrentMonthPurchases
    {
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
