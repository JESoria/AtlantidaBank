using System;
using System.Collections.Generic;

namespace AtlantidaBankAPI.Models
{
    public partial class ECrediCard
    {
        public ECrediCard()
        {
            ECrediCardUsers = new HashSet<ECrediCardUser>();
            TTransactions = new HashSet<TTransaction>();
        }

        public int CrediCardId { get; set; }
        public int CardTypeId { get; set; }
        public int StatusCrediCardId { get; set; }
        public string CardHolder { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public decimal CurrentBalance { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal BalanceAvailable { get; set; }

        public virtual CCardType CardType { get; set; } = null!;
        public virtual CStatusCrediCard StatusCrediCard { get; set; } = null!;
        public virtual ICollection<ECrediCardUser> ECrediCardUsers { get; set; }
        public virtual ICollection<TTransaction> TTransactions { get; set; }
    }
}
