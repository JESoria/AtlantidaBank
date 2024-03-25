namespace AtlantidaBankAPI.Models
{
    public class SP_GetAllTransactionsForCreditCard
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
    }
}
