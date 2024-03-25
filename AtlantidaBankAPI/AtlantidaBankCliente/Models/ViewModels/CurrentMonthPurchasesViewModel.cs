namespace AtlantidaBankCliente.Models.ViewModels
{
    public class CurrentMonthPurchasesViewModel
    {
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
