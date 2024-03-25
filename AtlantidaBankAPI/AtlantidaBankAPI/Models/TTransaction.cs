using System;
using System.Collections.Generic;

namespace AtlantidaBankAPI.Models
{
    public partial class TTransaction
    {
        public int TransactionId { get; set; }
        public int CrediCardId { get; set; }
        public string TransactionType { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Ipaddress { get; set; } = null!;

        public virtual ECrediCard CrediCard { get; set; } = null!;
    }
}
