namespace AtlantidaBankCliente.Models.ViewModels
{
    public class TransactionsForCreditCardViewModel
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
    }
}
