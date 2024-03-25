namespace AtlantidaBankAPI.Models.DTOs
{
    public class TransactionsForCreditCardDTO
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
    }
}
