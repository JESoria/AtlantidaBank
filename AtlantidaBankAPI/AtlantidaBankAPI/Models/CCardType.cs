using System;
using System.Collections.Generic;

namespace AtlantidaBankAPI.Models
{
    public partial class CCardType
    {
        public CCardType()
        {
            ECrediCards = new HashSet<ECrediCard>();
        }

        public int CardTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MinimumBalanceRate { get; set; }

        public virtual ICollection<ECrediCard> ECrediCards { get; set; }
    }
}
