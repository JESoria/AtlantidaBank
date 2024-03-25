namespace AtlantidaBankCliente.Models.ViewModels
{
    public class AccountStatementDetailViewModel
    {
        public int CrediCardId { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal BalanceAvailable { get; set; }
    }
}
